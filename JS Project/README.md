This is a tiny LISP compiler developed by javascript. 
This compiler is evaluating any LISP expression, for example '(add 2 (subtract 4 (add 2 1)))'.
Three phases to develop compiler:
1- Parsing phase: we here do lexical and syntax analysis
2- Transformation: transform code to the abstract syntax tree
4- Code Generation: convert code from LISP syntax to expression
