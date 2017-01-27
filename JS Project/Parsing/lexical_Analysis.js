function makeTokenizer(input){
    var tokens = [];
    var currentIndex=0;
    
    while(currentIndex < input.length){
        var char = input[currentIndex];
        if (char === '('){
            
            tokens.push({
                type:'paren',value:'('       
            });
            ++currentIndex;
            continue;
        }
        if(char ===')'){
            tokens.push({
               type:'paren',value:')' 
            });
            ++currentIndex;
            continue;
        }
        
        var whiteSpace=/\s/;
        if(whiteSpace.test(char)){
            currentIndex++;
            continue;
        }
        
        var number = /[0-9]/;
        if(number.test(char)){
            var value= '';
            
            while(number.test(char)){
                value +=char;
                char = input[++currentIndex];
                
            }
            
            tokens.push({
               type:'number',value:value 
            });
            
            continue;
        }
        var letters =/[a-z]/i;
         if(letters.test(char)){
             var value = '';
             while(letters.test(char)){
                 value +=char;
                 char = input[++currentIndex];
             }
             tokens.push({
                 type:'name',value:value
                 
             });           
             
             continue;
         }
       throw new TypeError('I dont know what this character is: ' + char);
        
    }
    
    return tokens;
}

var input = '(add 2 (subtract 4 (add 2 1)))';

function getTokens(){
    
    var token = makeTokenizer(input);
    return token;
}







