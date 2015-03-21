using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace Ex1
{
    class BMPReader
    {
        public int heigth { get; private set; }
        public int width  { get; private set; }

        private int pixel_array_offset;
        private short bits_per_pixel;

        private byte[] header;
        private Color[,] pixels;

        public BMPReader(string filename)
        {
            FileStream f;
            try
            {
                f = new FileStream(filename, FileMode.Open);
                if (is_bitmap(f))
                Console.WriteLine("Valide!");
                f.Close();
            } 
            catch (Exception e)
            {
                if (e.Message == "NonBitMap")
                    Console.WriteLine("ce n'est pas un Bitmap!");
                else
                    Console.WriteLine("Ce fichier n'existe pas");

                
            }
            f = new FileStream(filename, FileMode.Open);
            read_header(f);
            display_header();
            read_pixels(f);
            Console.Read();
            f.Close();

            
            
        }
        private bool is_bitmap(FileStream fs)
        {
            header = new byte[10];
            fs.Read(header,0,2);
            int magic_number = (header[0] << 8) + header[1];
            fs.Read(header, 0, 6);

            int size = header[0] + header[1] * 0x100 + header[2] * 0x10000 + header[3] * 0x1000000;
            if (magic_number != 0x424D && fs.Length != size)
                throw new Exception("NonBitMap");
            fs.Position = 0;
            return (magic_number == 0x424D && fs.Length == size);
        }
        public void save(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            fs.Write(header, 0, 54);
            for (int i = 0; i < heigth; i ++)
            {
                int j = 0;
                while (j < width)
                {
                    fs.WriteByte(pixels[i, j].R);
                    fs.WriteByte(pixels[i, j].G);
                    fs.WriteByte(pixels[i, j].B);
                }
                j *= 3;
                while (j % 4 != 0)
                {
                    fs.WriteByte(0);
                    j++;
                }
            }
        }

        public Color get_pixel(int x, int y)
        {
            return new Color();
        }
        public void set_pixel(int x, int y, Color c)
        {

        }
        private void display_header()
        {

            this.width = 0;  
            for (int i = 21; i >= 18; i--)
            {
                width = (width << 8) + header[i];
            }
            this.heigth = 0;
            for (int i = 25; i >= 22; i--)
            {
                heigth = (heigth << 8) + header[i];
            }

            this.pixel_array_offset = 0;
            for (int i = 13; i >= 10; i--)
            {
                pixel_array_offset = (pixel_array_offset << 8) + header[i];
            }

            this.bits_per_pixel = (short)(header[18] + header[19] * 256); 
            Console.WriteLine("Width: " + width + "pixels");
            Console.WriteLine("Heigth: " + heigth + "Pixels"  );
            Console.WriteLine("Offset: " + pixel_array_offset + "bytes");
            Console.WriteLine("bits per pixel : {0} bits",bits_per_pixel);
        }

        private void read_header(FileStream fs)
        {
            header = new byte[54];
            fs.Read(header, 0, 54);
        }


        private void read_pixels(FileStream fs)
        {
            fs.Position = pixel_array_offset;
            pixels = new Color[heigth, width];
            for (int i = 0; i < heigth; i++)
            {
                int j = 0;
                while (j < width)
                {
                    pixels[i, j] = Color.FromArgb(fs.ReadByte(), fs.ReadByte(), fs.ReadByte());
                    j++;
                }
                j *= 3;
                while (j % 4 != 0)
                {
                    fs.ReadByte();
                    j++;
                }
                    

            }
        }
    }
}
