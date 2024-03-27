using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filename = "C:\\Users\\katri\\source\\repos\\ProgramAlarm\\input.txt";

        int[] gravityAssistProgram = File.ReadAllText(filename)
                                          .Split(',')
                                          .Select(int.Parse)
                                          .ToArray();

        // Restore gravity assist program to "1202 program alarm" state
        gravityAssistProgram[1] = 12;
        gravityAssistProgram[2] = 2;

        RunIntcodeProgram(gravityAssistProgram);

        Console.WriteLine("Value left at position 0 after program halts: " + gravityAssistProgram[0]);
    }

    static void RunIntcodeProgram(int[] intcode)
    {
        int pointer = 0;

        while (true)
        {
            int opcode = intcode[pointer];

            if (opcode == 1)
            {
                int operand1 = intcode[intcode[pointer + 1]];
                int operand2 = intcode[intcode[pointer + 2]];
                intcode[intcode[pointer + 3]] = operand1 + operand2;
                pointer += 4;
            }
            else if (opcode == 2)
            {
                int operand1 = intcode[intcode[pointer + 1]];
                int operand2 = intcode[intcode[pointer + 2]];
                intcode[intcode[pointer + 3]] = operand1 * operand2;
                pointer += 4;
            }
            else if (opcode == 99)
            {
                break;
            }
            else
            {
                throw new ArgumentException("Unknown opcode encountered: " + opcode);
            }
        }
    }
}
