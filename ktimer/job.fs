
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

: endless ( -- )
    begin
        largedelay
        aaa @ 1 + aaa !
        ." still in endless .."
        cr .s
        aaa @ .
    again ;

: noending ( - )
  10 1 do 43 emit loop endless ;

: herefuu ( - )
  -99 -98 -97
  noending
;

: go herefuu ;


