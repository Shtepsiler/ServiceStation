namespace TaskManagerForMechanic.WEB.GraphQl.Inputs.Mechanic
{
    public record AddMechanicInput(
        string FirstName, 
        string LastName, 
        string Address, 
        string Phone, 
        string Password,
        string Specialization
        );
}
