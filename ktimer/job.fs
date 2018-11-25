\ program
variable aaa

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
  10 1 do 43 emit loop endless ;

: timer_aa ( -- )

  somedelay

  aaa @ \ get variable
  ." report aaa: "
  dup .

  1 + dup \ add 1 to int value stored at aaa and copy it for this test:
  \ ( aaa -- aaa 1 -- aaa+1 -- aaa+1 aaa+1 )
  59 > if \ ( aaa+1 aaa+1 -- a1 a1 59 -- a1 BOOL -- a1 )
      drop \ ( a1 -- )
      0    \ ( -- 0 )
      aaa ! \ ( 0 -- ) aaa: aaa=0
      cr exit then
  aaa !
  ." end of timer_aa: " .s cr
;

: herefuu ( - )
  -99 -98 -97

  0 aaa ! \ reset timer

  70 1 do timer_aa aaa @ . loop
  noending
;

: go herefuu ;

\ end
