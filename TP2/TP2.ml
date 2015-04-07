#load "graphics.cma";;
#load "Complex";;
open Complex;;
open Random;;
open Graphics;;
open_graph "";;


clear_graph();;


let draw x y l h = 
  moveto x (y + h/2);
  rlineto (-l/2) (-h);
  rlineto (l) (2*h/3);
  rlineto (-l) 0;
  rlineto (l) (-2*h/3);
  rlineto (-l/2) (h);;

draw 50 50 100 100;;


let b = [];;
Random.int(9);;
int(5);;
let rec mountain n x y z t = 
  match n with
    0 -> moveto x y;
        lineto z t
  |_ -> let m = (x+z)/2 in
	let h = (y+t)/2 + int(abs(z-x)/5+20)in
	mountain (n-1) x y m h;
	mountain (n-1) m h z t;;
	  
mountain 5 50 100 250 100;;

let rec dragon n x y z t =
  match n with 
    0 -> moveto x y;
         lineto z t
  | _ -> let u = (x+z)/2 + (t - y)/2 in
	 let v = (y+t)/2 - (z - x)/2 in 
	 dragon (n-1) x y u v;
	 dragon (n-1)z t u v;; 


dragon 18 50 400 250 400;;

let triangles x y c n = 
  let h n = int_of_float((sqrt(3.)/.2.)*.float_of_int(n))
  in 
  let draw x y c s = 
    moveto x y;
    lineto (x+c) y;
    lineto (x+c/2) (y + s * (h c));
    lineto x y
  in 
  let rec trace x y c n = 
    match n with 
      0 -> draw x y c (-1);
    | _ -> draw x y c (-1);
           trace (x-c/4) (y-(h c)/2) (c/2) (n-1);
	   trace (x+c/4) (y+(h c)/2) (c/2) (n-1);
	   trace (x+(3*c)/4) (y-(h c)/2) (c/2) (n-1)
  in 
  match n with 
    0 -> draw x y c 1
  | _ -> draw x y c 1;
         trace (x+c/4) (y+(h c)/2) (c/2) (n-1);;
    
triangles 50 50 600 6;;

let rec box1 x y c n =

  let c = c/3 in
  match n with 
    0 -> fill_rect x y c c;
         fill_rect x (y+2*c) c c;
	 fill_rect (x+2*c) y c c; 
	 fill_rect (x+c) (y+c) c c;
	 fill_rect (x+2*c) (y+2*c) c c
  | _ -> box x y c (n-1);
         box (x+c*2) y c (n-1);
	 box x (y+c*2) c (n-1);
	 box (x+c) (y+c) c (n-1);
	 box (x+c*2) (y+c*2) c (n-1);;


let k = let c b = (let a = b;;




clear_graph();;


abs(-.2.);;
2.**3.;;

box1 50 50 600 4 ;;

pow {re = 2.;im =0.} {re=2.;im=0.}
let a = {re = 3.;im = 2.};;





let mandelbrot  s kmax =
  clear_graph();
  let xmin = -2 and xmax = 1 and ymin = -1 and ymax = 1 in
  
  let rec test1 h j = 
    match j with
      s+1 when h = s ->()
    | s+1 -> ()
    | _ -> (let c = {re = float_of_int(xmin)+.
	float_of_int(h(xmax - xmin))/.float_of_int(s); 
	im = float_of_int(ymin)+.
	float_of_int(h(ymax - ymin))/.float_of_int(s)} and
	    let z = {re=0.;im=0.} 
	   and let k = 0 in
	       let rec test2 k z = 
		 match k with 
		   kmax ->  plot h j
		 | k when norm z+.1.<=2. -> test2 (k+1) (add (pow z {re=2.; im=0.}) c)
		 | _ ->();)
  in test1 0 0;;
	      
