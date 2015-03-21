(* C:\Users\epita\Documents\prog\test.ml *)
let rec  hanoi n a b  = 
   if n = 1 
   then
     begin
       print_int(a);
       print_string("->");
       print_int(b);
       print_newline()
     end
     else begin
            hanoi (n-1) a (6-a-b);
            hanoi 1 a b;
            hanoi (n-1) (6-a-b) b
	  end;;



hanoi 3 1 3;;


let occurrences c s =
  let rec occ i acc =
    if i < 0 then acc
    else occ (i - 1) (acc + if ((int_of_char (s.[i])) mod 32) = ((int_of_char c) mod 32) 
      then 1 
      else 0)
  in occ (String.length s - 1) 0;;

occurrences 'b' "bBbBbAdrsfegdfgdgaB";;

let count s1 s2 =
  let rec comp i n acc =
    if i < 0
    then acc
    else comp (i - 1) (n - 1) (acc + if s2.[n] = s1.[i] then 1 else 0)
  in
  let l = String.length s1 in

  let rec compteur x num =
      if x < (l - 1) 
      then num
      else compteur (x - 1) (num + (if (comp (l - 1) x 0) = l then 1 else 0))
  in 
compteur (String.length s2 - 1) 0;;


count "tot" "tototot";;

let anagramme s1 s2= 
  let rec test n =
    if n < 0 then true
    else ((occurrences (s1.[n]) s1) = (occurrences (s1.[n]) s2)) && (test (n-1))
  in test (String.length s1 - 1);;


anagramme "latex" "xeatal";;
