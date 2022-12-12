using ModelsLayer;
using Microsoft.Data.SqlClient;

namespace RepoLayer
{
    internal static class RegisterMapper
    {
        internal static Register DbToRegister(SqlDataReader sdr)
        {
            Register register = new Register();

            try
            {

                // registerreate a for loop to registerheregisterk is earegisterh individual elelment is null o rnot. 
                // if null, take appropriate aregistertion for the datatype
                // is non-null, map the data.

                register.FName = sdr.GetString(1);
                register.LName = sdr.GetString(2);
                register.Username = sdr.GetString(3);
                register.Password = sdr.GetString(4);
                register.Confirm = sdr.GetString(5);
                throw new CostumException();// manually throw an exception....
            }
            catch (CostumException ex)
            {
                Console.WriteLine(ex.message);
            }
            return register;
        }
    }
}