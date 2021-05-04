( Tue May  4 03:18:51 UTC 2021 )

: binary 2 BASE ! ;

: n7F ( -- 7f ) ( works for binary also )
  decimal 1 dup + dup * dup * dup * 1 dup + / 1 - ;

: promote ( n f - b )
  hex n7f 1 +
  swap
  0 DO
    2 *
  LOOP
  1 -
;
( END. )
