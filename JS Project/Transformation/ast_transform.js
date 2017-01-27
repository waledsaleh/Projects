var visitor = {
    NumberLiteral(node,parent){},
    CallExpression(node,parent){}
    
};

function traverser(ast, visitor) {
    
 function traverseArray(array, parent) {
    array.forEach(function(child) {
      traverseNode(child, parent);
    });
  }

  function traverseNode(node, parent) {

  
    var method = visitor[node.type];

  
    if (method) {
      method(node, parent);
    }

    switch (node.type) {

      case 'Program':
        traverseArray(node.body, node);
        break;

     
      case 'CallExpression':
        traverseArray(node.params, node);
        break;

     
      case 'NumberLiteral':
        break;

     
      default:
        throw new TypeError(node.type);
    }
  }

  traverseNode(ast, null);
}

function printAST(ast) {
  function traverseArray(array, parent, depth) {
    array.forEach(function(child) {
      traverseNode(child, parent,depth);
    });
  }

  function traverseNode(node, parent, depth) {
    let spaces = "";
    for(let i=0; i < depth; i ++) {
      spaces = spaces + "\t";
    }
    switch (node.type) {
      case 'Program':
        console.log(spaces, node.type);
        traverseArray(node.body, node, depth+1);
        break;
      case 'CallExpression':
        console.log(spaces, node.type);        
        traverseArray([node.callee], node, depth+1);
        traverseArray(node.arguments, node, depth+1);
        break;
      case 'ExpressionStatement':
        console.log(spaces, node.type);        
        traverseArray([node.expression], node, depth+1);
        break;
      case 'Identifier':
        console.log(spaces, node.type, ' - ', node.name);        
        break;
      case 'NumberLiteral':
        console.log(spaces, node.type,' - ', node.value);        
        break;
      default:
        throw new TypeError(node.type);
    }
  }
  traverseNode(ast, null, 0);
}
function transformer(ast) {

  var newAst = {
    type: 'Program',
    body: []
  };

  ast._context = newAst.body;

  traverser(ast, {

    NumberLiteral: function(node, parent) {
    
      parent._context.push({
        type: 'NumberLiteral',
        value: node.value
      });
    },

  
    CallExpression: function(node, parent) {
   
      var expression = {
        type: 'CallExpression',
        callee: {
          type: 'Identifier',
          name: node.name
        },
        arguments: []
      };

     
      node._context = expression.arguments;

     
      if (parent.type !== 'CallExpression') {

     
        expression = {
          type: 'ExpressionStatement',
          expression: expression
        };
      }

     
      parent._context.push(expression);
    }
  });

  
  return newAst;
}

var newAST = transformer(getTree());
printAST(newAST);
function getNewAST(){
    
    return newAST;

}

