(*TP 4*)
#load "graphics.cma";;
#load "unix.cma";;
open Graphics;;
open_graph ("");;



(*PALIER 0*)

let rec gen n = 
  match n with 
    0 -> []
  | n -> 0 :: gen (n-1);;



let rec gen_rand_list n =
  match n with 
    0 -> []
  | n -> (Random.int 2) :: gen_rand_list (n-1);;


let gen_board n = 
  let rec generate l b = 
    match l with 
      0 -> b
    | l -> generate (l-1) ((gen n) :: b)
  in generate n [];;


let gen_rand_board n = 
  let rec generate l b = 
    match l with 
      0 -> b
    | l -> generate (l-1) ((gen_rand_list n) :: b)
  in generate n [];;






(*PALIER 1*)

let cell_count l =
  let rec count l n =
    match l with 
      [] -> n
    | c :: l1 when c = 1 -> count l1 (n+1)
    | c :: l1 -> count l1 n
  in count l 0;;


let remaining b =
  let rec count b n = 
    match b with 
      [] -> n
    | l :: b1 -> count b1 (n + cell_count l)
  in count b 0;;






(*PALIER 2*)

let alive = red;;
let dead = blue;;


let draw_square (x,y) size = fill_rect x y size size;;


let draw_fill_square (x,y) size color =
  set_color color;
  draw_square (x,y) size;;


let draw_cell (x,y) size cell =
  if cell = 1 
  then draw_fill_square (x,y) size alive
  else draw_fill_square (x,y) size dead;;



   

let draw_board board size =      

(* Cette fonction affiche une liste de cellules sous la forme d'une colonne 
   en affichant chaque cellule puis en montant d'un cran a chaque fois *)
  let rec draw_column x y l =
    match l with 
      [] -> ()
    | c :: l1 -> draw_cell ((size*x),(size*y)) size c;
                 draw_column x (y+1) l1
  in 

(* Cette fonction fait la meme chose sauf qu'ici elle utilise draw_column 
   au lieu de draw_cell *)
 
  let rec paint board x = 
    match board with 
      [] -> ()
    | l :: board1 -> draw_column x 0 l;
                 paint board1 (x+1)
  in 
  
  paint board 0;;


draw_board (gen_rand_board 10) 50;;






(*PALIER 3*)

let rec get_cell (x,y) board =
  match board with 
    [] -> failwith "x out of bounds"
  | [] :: b -> failwith "y out of bounds"
  | l :: b when x <> 1 -> get_cell (x-1,y) b
  | (c :: l) :: b when y <> 1 -> get_cell (x,y-1) (l :: b)
  | (c :: l) :: b -> c;;


let replace_cell value (x,y) board =
  let rec reach_cell y l =
    match l with 
      [] -> failwith "y out of bounds"
    | c :: l1 when y = 1 -> value :: l1
    | c :: l1 -> c :: (reach_cell (y-1) l1)
  in 
  let rec reach_column x b = 
    match b with 
      [] -> failwith "x out of bounds"
    | l :: b1 when x = 1 -> (reach_cell y l) :: b1
    | l :: b1 -> l :: (reach_column (x-1) b1)
  in 
  reach_column x board;;


let rec get_board_size b n= 
    match b with 
      [] -> n 
    | l :: b1 -> get_board_size b1 (n+1);;

  
let seed_life board n =
  let rec give_life n (x,y) b s = 
    match (n,(x,y)) with
      (0,_) -> b
    | (n,(x,y)) when get_cell (x,y) b = 0 -> give_life (n-1) (x,y) (replace_cell 1 (x,y) b) s
    | (n,_) ->  give_life n ((Random.int s) + 1,(Random.int s) + 1) b s
  in 
  let s = get_board_size board 0
  in 
  give_life n ((Random.int s) + 1,(Random.int s) + 1) board s;;



 
let get_cell_neighborhood (x,y) board =
  let potential_neighbors = [(x-1,y);(x-1,y+1);(x,y+1);(x+1,y+1);
			     (x+1,y);(x+1,y-1);(x,y-1);(x-1,y-1)]
  in
  let is_valid (x,y) = x <= get_board_size board 0 && y <= get_board_size board 0 && y > 0 && x > 0
  in
  let rec get_neighbors l  = 
      match l with 
	[] -> []
      | c :: l1 when is_valid c -> (get_cell c board) :: (get_neighbors l1) 
      | c :: l1 -> get_neighbors l1
  in 
  get_neighbors potential_neighbors;;


get_cell_neighborhood (2,1) [[11;12;13;14];
			     [21;22;23;24];
			     [31;32;33;34];
			     [41;42;43;44]];;





(*PALIER 4*)

let iterate board = 
  let s = get_board_size board 0
  in
  let rec get_environment coords =
    (get_cell coords board,
     cell_count (get_cell_neighborhood coords board))
  in
  let rec act (x,y) b = 
    match (x,y) with
      (x,_) when x > s -> b
    | (_,y) when y > s -> act (x+1,1) b
    | c -> match get_environment c with	
      | (1,n) when n < 2 || n > 3 -> act (x,y+1) (replace_cell 0 c b)
      | (0,3) -> act (x,y+1) (replace_cell 1 c b)
      | _ -> act (x,y+1) b
  in act (1,1) board;;


let b = [[0;1;1;0;0];
	 [1;1;0;1;0];
	 [0;0;1;0;1];
	 [1;1;1;0;0];
	 [1;0;0;0;1]];;

iterate b;;

let play board =
  let rec iter b =
    match remaining b with 
      0 -> draw_board b 50
    | _ -> Unix.sleep (1);
           draw_board b 50;
	   iter (iterate b)
  in 
  let s = string_of_int((get_board_size board 0)*50+40)
  in 
  open_graph (s^"x"^s);
  iter board;;
play (gen_rand_board 15);;


(*PALIER 5: let's get serious*)
 

let rec gen_rand_listHP n =
  match n with 
    0 -> []
  | n -> ((Random.int 2)*10) :: gen_rand_listHP (n-1);;


let gen_rand_boardHP n = 
  let rec generate l b = 
    match l with 
      0 -> b
    | l -> generate (l-1) ((gen_rand_listHP n) :: b)
  in generate n [];;

let b = gen_rand_boardHP 5;;

let cell_countHP l =
  let rec count l n =
    match l with 
      [] -> n
    | c :: l1 when c = 0 -> count l1 n
    | c :: l1 -> count l1 (n+1)
  in count l 0;;


let remainingHP b =
  let rec count b n = 
    match b with 
      [] -> n
    | l :: b1 -> count b1 (n + cell_countHP l)
  in count b 0;;

remainingHP (b)



let color = function 
    0 -> black 
  | a when a < 10 -> rgb ((255/10)*a) 0 0
  | a when a < 20 -> 255  ((255/10)*(a-10)) 0
  | a when a < 30 -> rgb 255 255 ((255/10)*(a-20))
  | _ -> white ;;

let draw_cellHP (x,y) size cell =
  draw_fill_square (x,y) size (color cell);;


let draw_boardHP board size = 

  let rec draw_column x y l =
    match l with 
      [] -> ()
    | c :: l1 -> draw_cellHP ((size*x),(size*y)) size c;
                 draw_column x (y+1) l1
  in 
  let rec paint b x = 
    match b with 
      [] -> ()
    | l :: b1 -> draw_column x 0 l;
                 paint b1 (x+1)
  in 
  
  paint board 0;;

open_graph "";;


let iterateHP board = 
  let s = get_board_size board 0
  in
  let rec get_environment coords =
    (get_cell coords board,
     cell_countHP (get_cell_neighborhood coords board))
  in
  let change c v =
    match c with 
      n when (n+v) < 0 -> 0
    | n -> n+v
  in 
  let rec act (x,y) b = 
    match (x,y) with
      (x,_) when x > s -> b
    | (_,y) when y > s -> act (x+1,1) b
    | c -> match get_environment c with	
      | (a,n) when a > 0 && n < 2 -> act (x,y+1) (replace_cell (change a (-2)) c b)
      | (a,n) when a > 0 && n > 3 -> act (x,y+1) (replace_cell (change a (-5)) c b)
      | (0,3) -> act (x,y+1) (replace_cell 10 c b)
      | (a,3) -> act (x,y+1) (replace_cell (a+1) c b)
      | _ -> act (x,y+1) b
  in act (1,1) board;;


let playHP board =
  let rec iter b =
    match remainingHP b with 
      0 -> draw_boardHP b 50
    | _ -> Unix.sleep (1);
           draw_boardHP b 50;
	   iter (iterateHP b)
  in 
  let s = string_of_int((get_board_size board 0)*50+40)
  in 
  open_graph (s^"x"^s);
  iter board;;

playHP (gen_rand_boardHP 15);;





let b = [[0;10;10;0;0];
	 [10;10;0;10;0];
	 [0;0;10;0;10];
	 [10;10;10;0;0];
	 [10;0;0;0;10]];;
iterateHP [[11; 5; 11]; [5; 5; 5]; [11; 5; 11]];;


open_graph "310x340";;

draw_board10 [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] 100
