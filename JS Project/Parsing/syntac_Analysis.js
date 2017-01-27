function parser(tokens){
    var current = 0;
    function convertTokens(){
        var token = tokens[current];
        
        if(token.type==='number'){
            ++current;
            return {
              type:'NumberLiteral',
              value :token.value
                
            };
            
        }
        if(token.type==='paren'&& token.value==='('){
            token = tokens[++current];
            
            var node = {
              type:'CallExpression',
                name:token.value,
                params:[]
                
            };
            
            token = tokens[++current];
            
       while ((token.type !== 'paren') ||
        (token.type === 'paren' && token.value !== ')')) {
       
        node.params.push(convertTokens());
        token = tokens[current];
           
      }
            ++current;
            return node;
            
        }
        
        throw new TypeError(token.type);
    }
    var rootTree = {
      type:'Program',
        body:[]
    };
    
    while (current <tokens.length){
        rootTree.body.push(convertTokens());
        
    }
    return rootTree;
}


function printAST(rootTree){
    
    function traverseTree(array,parent,depth){
        
        array.forEach(function (child){
                    traverseNode(child,parent,depth); 
                     
                     });
        
    }
    function traverseNode(node,parent,depth){
    let spaces="";
    for(let i=0;i<depth;++i){
        spaces +="\t";
    }
    
    switch(node.type){
        case 'Program':
            console.log(spaces,node.type);
            traverseTree(node.body,node,depth+1);
            break;
        case 'CallExpression':
            console.log(spaces, node.type, ' - ', node.name);        
            traverseTree(node.params, node, depth+1);
           break;
        case 'NumberLiteral':
        console.log(spaces, node.type,' - ', node.value);        
           break;
        default:
           throw new TypeError(node.type);
    }
        
    }
     traverseNode(rootTree,null,0);
}



var treeShow = parser(getTokens());
printAST(treeShow);
function getTree(){
    
    return treeShow;
}

    





