class Solution {

    fun sortSolution(equation: List<String>) {
        var operatorsFound = 0
        for (item in equation) {
            if (item == "+" || item == "-" || item == "*" || item == "/" || item == "^" || item == "%") {
                operatorsFound++
            }
        }

        if (operatorsFound == 1) {
            startSolvingSimple(equation)
        } else {
            startSolvingComplex(equation)
        }
    }

    fun startSolvingSimple(equation: List<String>) {
        val operator = equation[1]

        val num1 = equation[0].toDouble()
        val num2 = equation[2].toDouble()
        var result = 0.0
        when (operator) {
            "+" -> result = num1 + num2
            "-" -> result = num1 - num2
            "*" -> result = num1 * num2
            "/" -> result = num1 / num2
            "^" -> result = Math.pow(num1, num2)
            "%" -> result = num1 % num2
        }
        println(result)
    }

    fun startSolvingComplex(equation: List<String>) {
        var paranthesisFound = 0

        for(item in equation) {
            if(item == "(" || item == ")"){
                paranthesisFound ++
            }
        }

    }
}