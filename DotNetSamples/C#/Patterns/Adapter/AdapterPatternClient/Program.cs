
using AdapterPattern;

string[,] employeesArray = new string[5, 4]
{
    {"101","John","SE","10000"},
    {"102","Smith","SE","20000"},
    {"103","Dev","SSE","30000"},
    {"104","Pam","SE","40000"},
    {"105","Sara","SSE","50000"}
};

ITarget target = new Adapter();

//employeesarray is de one from hr that needs to be adapted to our project salary 

target.processCompanySalary(employeesArray);

Console.Read();