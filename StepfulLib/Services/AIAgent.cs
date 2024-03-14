using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using StepfulLib;

namespace StepfulLib;

public interface IAgent
{
    public string Echo(string str);
    public KernelFunction AIFunction { get; set; }
    public Kernel AIKernel { get; set; }
    public KernelFunction Create(string prompt);
}

public class AiSettings
{
    public string Model { get; set; }

    public string Key { get; set; }
}

public class Agent : IAgent
{

    public KernelFunction AIFunction { get; set; }
    public Kernel AIKernel { get; set; }

    public Agent (AiSettings aiSettings)
    {
        var ai_builder = Kernel.CreateBuilder();
        ai_builder.AddOpenAIChatCompletion(aiSettings.Model, aiSettings.Key);
        AIKernel = ai_builder.Build();
    }


    public string Echo(string str)
    {
        if(AIKernel == null)
        {
            return "fail";
        }
        return "echo: " + str;
    }

    //public Agent() //_string Prompt = "You are a calendar scheduling AI Agent. You strictly speak JSON.")
    //public string GeneratePrompt(string type, string location)
    //{
    //    return $"Which coach is recommended for {type} near {location}";
    //}

    public string MultiplyPrompt(string num1, string num2)
    {
        return $"Whats the product of {num1} and {num2}?";
    }

    [KernelFunction, Description("Multiply two numbers together")]
    public static float MultiplyTwoNumbers([Description("The first number")] float number1, [Description("The second number")] float number2)
    {
        return number1 * number2;
    }


    public KernelFunction Create(string prompt)
	{
        OpenAIPromptExecutionSettings executionSettings = new OpenAIPromptExecutionSettings { MaxTokens = 100 };
        KernelFunction kf = AIKernel.CreateFunctionFromPrompt(prompt, executionSettings);
        this.AIFunction = kf;
        return kf;


        //kernel.InvokeAsync(kf);
    }
}



public class AgentTest
{
    public Agent StudentAgent { get; set; }
    public Agent CoachAgent { get; set; }
    public Agent SystemAgent { get; set; }

    public AgentTest()
    {
        //StudentAgent = new Agent("Your are Calendar Schedulng AI Agent specifically for the students to find and connect with coaches to book 2 hour time-slots on their calendar with each other. You strictly speak JSON to work with the client application.");
        //CoachAgent = new Agent("Your are Calendar Schedulng AI Agent specifically for the coaches to let students find and connect with you to book 2 hour time-slots on your calendar with them. You strictly speak JSON to work with the client application.");
    }
}

