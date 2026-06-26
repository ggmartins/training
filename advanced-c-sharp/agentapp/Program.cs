using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;

//# Add the Microsoft Agent Framework package
//dotnet add package Microsoft.Agents.AI

//# Add the provider package (Choose ONE based on your AI provider)
//# For standard OpenAI:
//dotnet add package Microsoft.Agents.AI.OpenAI --prerelease
//dotnet add package OpenAI
//
//# OR for Azure AI Foundry / Azure OpenAI:
//# dotnet add package Microsoft.Agents.AI.Foundry --prerelease
//# dotnet add package Azure.Identity

//export OPENAI_API_KEY="your-actual-api-key-here"


// 1. Initialize the baseline OpenAI client (looks for OPENAI_API_KEY env var automatically)
var openAIClient = new OpenAIClient();

// 2. Wrap it with Microsoft.Extensions.AI abstraction layer
IChatClient chatClient = openAIClient.GetChatClient("gpt-4o-mini").AsIChatClient();

// 3. Construct your Microsoft Agent with dedicated persona guidelines
AIAgent agent = chatClient.CreateAIAgent(
    instructions: "You are a professional software architect. Give precise, highly-technical, and direct code feedback."
);

// 4. Run the agent natively
Console.Write("Ask the Agent: ");
string userPrompt = Console.ReadLine() ?? "Explain dependency injection in 2 sentences.";

var response = await agent.RunAsync(userPrompt);

Console.WriteLine($"\n[Agent Response]:\n{response}");
