class Calculator {

    fun main(args: Array<String>) {
        println("******** Calculator ********")
        println("This Calculator can perform the following operations:")
        println("Addition, Subtraction, Multiplication, Division, Exponents and Modulus")
        println("Enter the operation you want to perform: example 1 + 2")
        println("To exit the program type 'exit'")
        print("> ")
        // Read user input using a
        var input = readLine()
        var runProgram = true
        while (runProgram == true) {


            //println("You entered: $input")
            val equation = seperateInput(input!!)

            val getSolution = Solution()
            getSolution.sortSolution(equation)

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
        val items = mutableListOf<String>()
        var currentItem = ""

        for (char in input) {
            if (char.isDigit() || char == ' ') {
                currentItem += char
            } else {
                if (currentItem.isNotEmpty()) {
                    items.add(currentItem.trim())
                    currentItem = ""
                }
                items.add(char.toString())
            }
        }

        if (currentItem.isNotEmpty()) {
            items.add(currentItem.trim())
        }

        return items

    }
}

