<Query Kind="Statements" />

void Main()
{
 SayHello("Leban");
}

public void SayHello(string name)
{
string message = "hello " + name + " world";
message.Dump();
}
