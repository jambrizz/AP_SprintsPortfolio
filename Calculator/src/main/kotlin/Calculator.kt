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

    fun seperateInput(input: String): List<String> {
        val stringEquation = input



        return input.split(" ")
    }
}

