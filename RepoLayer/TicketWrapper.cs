using ModelsLayer;
using Microsoft.Data.SqlClient;

namespace RepoLayer
{
    internal static class TicketWrapper
    {
        internal static Tickets DbToRegister(SqlDataReader sdr)
        {
            Tickets ticket = new Tickets();

            try
            {

                // registerreate a for loop to registerheregisterk is earegisterh individual elelment is null o rnot. 
                // if null, take appropriate aregistertion for the datatype
                // is non-null, map the data.

                ticket.empId = Convert.ToInt32(1);
                ticket.reimbursment = sdr.GetString(2);
                ticket.valueDollar = sdr.GetDouble(3);
                ticket.description = sdr.GetString(4);
                ticket.status = sdr.GetString(5);
                throw new CostumException();// manually throw an exception....
            }
            catch (CostumException ex)
            {
                Console.WriteLine(ex.message);
            }
            return ticket;
        }
    }
}