\ program
variable aaa

: escemit ( -- )
  27 emit ;

: lbrktemit ( -- )
  [char] [ emit ;

: twojayemit ( -- )
  [char] J [char] 2 emit emit ;

: Acoordemit ( -- )
  [char] 7 emit [char] A emit ;

: upemit ( -- )
  escemit lbrktemit
  Acoordemit ;

: clearscreen ( -- )
  escemit lbrktemit twojayemit upemit ;

: somedelay ( -- )
  10000000
  1 do 1 drop loop ;

: largedelay ( -- )
    10 1 do somedelay loop ;

: endlesstwo ( -- )
       0 begin
         dup . 1+
         somedelay
       again ;

: endlessthree ( -- ) \ best
    begin
        aaa @ 1 + aaa !
        ." still in endless .."
        cr .s
        aaa @ .
    again ;


: endless ( -- )
    begin
        largedelay
    again ;



: noending ( - )
  10 1 do space \ 43 emit
  loop endless ;


\ fence
: fmt_print_a ( -- )
  cr
  space
  space
  [char] : emit

  aaa @ \ ( -- aaa )
  10 < if  ( aaa -- aaa 9 -- bool )
    $30 emit \ space \ 43 emit
    \ .s
    then
;

: timer_aa ( -- )

  largedelay
  largedelay
  largedelay
  largedelay
  largedelay
  clearscreen

  aaa @ \ get variable
  \ ." report aaa: "

  fmt_print_a dup .

  cr \ all paths
  44 emit 44 emit 44 emit \ three commas
  1 + dup \ add 1 to int value stored at aaa and copy it for this test:
  \ ( aaa -- aaa 1 -- aaa+1 -- aaa+1 aaa+1 )
  59 > if \ ( aaa+1 aaa+1 -- a1 a1 59 -- a1 BOOL -- a1 )
      drop \ ( a1 -- )
      0    \ ( -- 0 )
      aaa ! \ ( 0 -- ) aaa: aaa=0
      \ cr
      exit then
  aaa !
  \ ." end of timer_aa: " .s cr
;

: herefuu ( - )
  -99 -98 -97

  0 aaa ! \ reset timer

  700 1 do
      timer_aa
      \ aaa @ fmt_print_a .
      cr
      loop

  noending
;

: go herefuu ;

\ end
