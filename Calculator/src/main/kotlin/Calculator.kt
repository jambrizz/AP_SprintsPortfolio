class Calculator {

    fun main(args: Array<String>) {
        println("******** Calculator ********")
        println("This Calculator can perform the following operations:")
        println("Addition, Subtraction, Multiplication, Division")
        println("Enter the operation you want to perform: example 1 + 2")
        println("To exit the program type 'exit'")
        print("> ")
        // Read user input using a
        var input = readLine()
        var runProgram = true
        while (runProgram == true) {


            println("You entered: $input")
            val equation = seperateInput(input!!)
            for(i in equation) {
                println("Equation: $i")
            }
            print("> ")
            input = readLine()

            if (input == "exit") {
                runProgram = false
                println("Exiting Calculator, Thank you for using it!")
            }
            else {
                //TODO: Call the function to seperateInput to get the numbers and the operator
            }
        }
    }

    // Function to seperate the input into numbers and operator
    fun seperateInput(input: String): List<String> {
        var blankSpace = 0
        val lenOfInput = input.length
        println("Lenght of input: $lenOfInput")
        for(i in 0 until lenOfInput) {
            //println("Index: $i")
            //println("Char: ${input[i]}")
            if(input[i] == ' ') {
                blankSpace ++
            }
        }

        return if(blankSpace > 0){
            input.split("").filter{it.isNotBlank()}
        } else{
            input.map{it.toString()}
        }

    }
}

