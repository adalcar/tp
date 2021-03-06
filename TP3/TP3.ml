(* C:\Users\epita\Documents\prog\TP3.ml *)
#load "unix.cma";;
(*PALIER 0*)

Unix.sleep 2;;
let rec are_equal a b = 
  match (a,b) with
    [],[] -> true
  | [],_ | _,[] -> false
  | (a::b),(c::d)  when a = c -> are_equal b d
  | _ -> false;;



let rec append a b = 
  match a with 
    [] -> b
  | x::k -> x::append k b;;

let reverse a = 
  let rec rev a b = 
    match a with 
      [] -> b
    | a::l -> rev l (a::b)
  in rev a [];;

let rec print a = 
  match a with 
    [] -> print_newline()
  | b::l -> print_char(b);
            print l;;

print['j';'e';' ';'s';'u';'i';'s';' ';'u';'n';' ';'g';'e';'n';'i';'e'];;

let rec to_list

(*PALIER 1*)

let rec is_morse a =
  match a with 
    [] -> true
  | b::l when b = '.' || b = '-'  -> is_morse l
  | _ -> false;;

is_morse ['-';'-';'-'];;

let letter_to_morse a =
  match a with 
    'a' | 'A' -> ['.';'-']
  | 'b' | 'B' -> ['-';'.';'.';'.']
  | 'c' | 'C' -> ['-';'.';'-';'.']
  | 'd' | 'D' -> ['-';'.';'.']
  | 'e' | 'E' -> ['.']
  | 'f' | 'F' -> ['.';'.';'-';'.']
  | 'g' | 'G' -> ['-';'-';'.']
  | 'h' | 'H' -> ['.';'.';'.';'.']
  | 'i' | 'I' -> ['.';'.']
  | 'j' | 'J' -> ['.';'-';'-';'-']
  | 'k' | 'K' -> ['-';'.';'-']
  | 'l' | 'L' -> ['.';'-';'.';'.']
  | 'm' | 'M' -> ['-';'-']
  | 'n' | 'N' -> ['-';'.']
  | 'o' | 'O' -> ['-';'-';'-']
  | 'p' | 'P' -> ['.';'-';'-';'.']
  | 'q' | 'Q' -> ['-';'-';'.';'-']
  | 'r' | 'R' -> ['.';'-';'.']
  | 's' | 'S' -> ['.';'.';'.']
  | 't' | 'T' -> ['-']
  | 'u' | 'U' -> ['.';'.';'-']
  | 'v' | 'V' -> ['.';'.';'.';'-']
  | 'w' | 'W' -> ['.';'-';'-']
  | 'x' | 'X' -> ['-';'.';'.';'-']
  | 'y' | 'Y' -> ['-';'.';'-';'-']
  | 'z' | 'Z' -> ['-';'-';'.';'.']
  | '1' -> ['.';'-';'-';'-';'-']
  | '2' -> ['.';'.';'-';'-';'-']
  | '3' -> ['.';'.';'.';'-';'-']
  | '4' -> ['.';'.';'.';'.';'-']
  | '5' -> ['.';'.';'.';'.';'.']
  | '6' -> ['-';'.';'.';'.';'.']
  | '7' -> ['-';'-';'.';'.';'.']
  | '8' -> ['-';'-';'-';'.';'.']
  | '9' -> ['-';'-';'-';'-';'.']
  | '0' -> ['-';'-';'-';'-';'-']
  
  | _ -> failwith "PAS UN CARACTERE CONNARD";;

letter_to_morse('6')
(*PALIER 2*)

let rec word_to_morse s =
  match s with 
  | [] -> []
  | a::l -> letter_to_morse(a)::word_to_morse(l);;

word_to_morse ['S';'O';'S'];;


let rec to_single_list l = 
  match l with 
  | [] -> []
  | l2::l3 -> match l2 with 
            | [] when l3 = []-> []
	    | [] -> ' '::to_single_list(l3) 
	    | k::l4 -> k::to_single_list(l4::l3);;


to_single_list(word_to_morse ['S';'O';'S']);;

let print_morse l = 
  let n = String.length(l) in
  let rec to_list n =
    match n with 
      0 -> [l.[0]]
    | n -> append (to_list (n-1)) [(l.[n])]
  in word_to_morse(to_list (n-1));;

print_morse "troll";;

(*PALIER 3*)

let rec sentence_to_morse l =
  match l with
    [] -> []
  | a::k -> word_to_morse (a) :: sentence_to_morse (k);;

let rec sentence_to_single_list l = 
  match l with 
  | [] -> []
  | k::m -> match k with 
    | [] when m <> []-> '/' :: (sentence_to_single_list m)
    | [] -> []
    | n::o -> match n with 
      | [] when o <> []-> ' ':: (sentence_to_single_list (o::m)) 
      | [] ->  sentence_to_single_list (o::m)
      | a::k -> a::sentence_to_single_list ((k::o)::m);;



let to_single_morse a =
  to_single_list(word_to_morse a);;

let latin_sentence_to_single a =
  sentence_to_single_list(sentence_to_morse a);;


(*PALIER 4*)

let to_morse a = 
  match a with 
  | 'a' | 'A' -> ".-"
  | 'b' | 'B' -> "-..."
  | 'c' | 'C' -> "-.-."
  | 'd' | 'D' -> "-.."
  | 'e' | 'E' -> "."
  | 'f' | 'F' -> "..-."
  | 'g' | 'G' -> "--."
  | 'h' | 'H' -> "...."
  | 'i' | 'I' -> ".."
  | 'j' | 'J' -> ".---"
  | 'k' | 'K' -> "-.-"
  | 'l' | 'L' -> ".-.."
  | 'm' | 'M' -> "--"
  | 'n' | 'N' -> "-."
  | 'o' | 'O' -> "---"
  | 'p' | 'P' -> ".--."
  | 'q' | 'Q' -> "--.-"
  | 'r' | 'R' -> ".-."
  | 's' | 'S' -> "..."
  | 't' | 'T' -> "-"
  | 'u' | 'U' -> "..-"
  | 'v' | 'V' -> "...-"
  | 'w' | 'W' -> ".--"
  | 'x' | 'X' -> "-..-"
  | 'y' | 'Y' -> "-.--"
  | 'z' | 'Z' -> "--.."
  | '0'       -> "-----"
  | '1'       -> ".----"
  | '2'       -> "..---"
  | '3'       -> "...--"
  | '4'       -> "....-"
  | '5'       -> "....."
  | '6'       -> "-...."
  | '7'       -> "--..."
  | '8'       -> "---.."
  | '9'       -> "----."
  | _         -> failwith "fuck off";;
  
let latin_to_morse a = 
  let n = String.length a
  in let rec translate i =
       match i with 
	 i when i = n -> "/"
       | _ -> match a.[i] with
	 | ' ' -> "/" ^ translate (i+1)
	 | c -> (to_morse c) ^ "/" ^ translate (i+1)
     in translate 0;;

latin_to_morse "vive les listes"


(*PALIER 5*)

let to_list s = 
  let n = String.length s in
  let rec add x y = 
    match x with 
      x when x = n-1 -> [String.sub s y (x-y)]
    | x when s.[x] = ' ' -> (String.sub s y (x-y)):: (add (x+1) (x+1))
    | x when s.[x] = '/' -> (String.sub s y (x-y)):: " "::(add (x+1) (x+1))
    | _ -> add (x+1) y
  in add 0 0;; 

to_list "... --- .../... --- .../";;



let to_latin a = 
    match a with
      ".-"    -> "A"
    | "-..."  -> "B"
    | "-.-."  -> "C"
    | "-.."   -> "D"
    | "."     -> "E"
    | "..-."  -> "F"
    | "--."   -> "G"
    | "...."  -> "H" 
    | ".."    -> "I"
    | ".---"  -> "J"
    | "-.-"   -> "K"
    | ".-.."  -> "L"
    | "--"    -> "M"
    | "-."    -> "N" 
    | "---"   -> "O"
    | ".--."  -> "P"
    | "--.-"  -> "Q"
    | ".-."   -> "R"
    | "..."   -> "S"
    | "-"     -> "T"
    | "..-"   -> "U"
    | "...-"  -> "V"
    | ".--"   -> "W"
    | "-..-"  -> "X"
    | "-.--"  -> "Y"
    | "--.."  -> "Z"
    | ".----" -> "1"
    | "..---" -> "2"
    | "...--" -> "3"
    | "....-" -> "4"
    | "....." -> "5"
    | "-...." -> "6"
    | "--..." -> "7"
    | "---.." -> "8"
    | "----." -> "9"
    | "-----" -> "0"
    | " "     -> " "
    | _       -> "";;



let rec list_to_latin_string l = 
  match l with 
    [] -> ""
  | a::l2 -> (to_latin a)^(list_to_latin_string l2);;

let morse_to_latin s =
  list_to_latin_string(to_list s);;
morse_to_latin "...- .. ...- ./.-.. . .../.-.. .. ... - . .../"
;;
let wait_n_print a = 
 let wait time = 
    Unix.select[][][](float_of_int(time)/.1000.);
 in wait a;
 print_string("done");;

wait_n_print 500; print_newline();;



let print_in_rythm s =
  let l = String.length(s) in

   let rec print n =
       Unix.sleep(1);
       match n with  
	 n when n = l -> print_newline()
       | n when s.[n] = ' ' -> print_char(' ');
	                       print_string ("\n");
	                       Unix.sleep (2);
			       print (n+1)
	                       
       | n when s.[n] = '/' -> print_char('/');
	                       Unix.sleep(6);
                               print (n+1)

       | n when s.[n] = '.' -> Unix.sleep(1);
	                       print_char('.');
			       print (n+1)
       | n when s.[n] = '-' -> Unix.sleep(3);
	                       print_char('-');
			       print (n+1)
       | _ -> print_string ("fuck off")
     in print 0;;
	 
print_in_rythm "... --- .../... --- ...";;
