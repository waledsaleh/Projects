var stackNumbers=[];
var stackOps=[];

function codeGenerator(node) {

  switch (node.type) {
    case 'Program':
      return node.body.map(codeGenerator)
        .join('\n');
          
    case 'ExpressionStatement':
      return (
        codeGenerator(node.expression) +
        ';'
      );

    case 'CallExpression':
      return (
        codeGenerator(node.callee) +
        '(' +
        node.arguments.map(codeGenerator)
          .join(', ') +
        ')'
      );

    case 'Identifier':
         if(node.name=="add"){stackOps.push('+');return '+';}
          
          stackOps.push('-');
      return '-';

    case 'NumberLiteral':
          
      stackNumbers.push(node.value);
      return node.value;

    default:
      throw new TypeError(node.type);
  }
}

var output = codeGenerator(getNewAST());

console.log(output);
console.log(stackNumbers);
console.log(stackOps);

var counter =stackOps.length;
while(counter--){
     var char = stackOps.pop();
     var n1 = parseInt(stackNumbers.pop()),n2 =parseInt(stackNumbers.pop());
  
     stackNumbers.push( char == '+' ? n1+n2 : n2-n1 );
   
}

console.log(stackNumbers[0]);


