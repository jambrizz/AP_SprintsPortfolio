class Solution {

    fun sortSolution(equation: List<String>) {
        var operatorsFound = 0
        var lettersFound = 0
        for (item in equation) {
            if (item == "+" || item == "-" || item == "*" || item == "/" || item == "^" || item == "%") {
                operatorsFound++
            }

            //Check if the item is a letter using regex expression
            if(item.matches(Regex("[a-zA-Z]"))) {
                lettersFound++
            }
        }

        if (operatorsFound == 1 && lettersFound < 1) {
            startSolvingSimple(equation)
        } else if(operatorsFound == 0) {
            println("No operator found in the equation")
        } else if(operatorsFound == 1 && lettersFound >=1) {
            println("Invalid input! You entered a letter in the equation")
        } else {
            println("Complex Equation Detected! This application can only solve simple equations.")
        }
    }

    fun startSolvingSimple(equation: List<String>) {
        //This unmutable variable will hold the operator
        val operator = equation.find{ it in setOf("+", "-", "*", "/", "^", "%")}

        //This variable will hold the index of the operator in the list
        val indexOfOperator = equation.indexOf(operator)

        //This variable will hold the first number in the equation
        val num1 = equation.subList(0, indexOfOperator).joinToString("").toDouble()
        //This variable will hold the second number in the equation
        val num2 = equation.subList(indexOfOperator + 1, equation.size).joinToString("").toDouble()
        val result = when (operator) {
            "+" -> num1 + num2
            "-" -> num1 - num2
            "*" -> num1 * num2
            "/" -> num1 / num2
            "^" -> Math.pow(num1, num2)
            "%" -> num1 % num2
            else -> throw IllegalArgumentException("Invalid operator")
        }
        println(result)
    }
}