
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{

    /**
    Server=tcp:revatureadmir.database.windows.net,1433;
    Initial Catalog=RevatureAdmir;
    Persist Security Info=False;
    User ID=admir;
    Password={your_password};
    MultipleActiveResultSets=False;
    Encrypt=True;
    TrustServerCertificate=False;
    Connection Timeout=30;
    
    */
    public interface IRepoLayerClass
    {
        Task<Register> login(string username, string password);

        Task<Register> signup(Register r);

        Task<List<Register>> getAllUsers();

        Task<Tickets> addTicket(Tickets ticket);

        Task<Tickets> approveTicket(string status);

        Task<List<Tickets>> getAllPendingTickets(int empId, string status);

        Task<List<Tickets>> getByUserId(int empId);
    }

    public class RepoLayerClass : IRepoLayerClass
    {

        private readonly Logger _logger;

        SqlConnection conn = new SqlConnection("Server=tcp:revatureadmir.database.windows.net,1433;" +
             "Initial Catalog=RevatureAdmir;Persist Security Info=False;" +
             "User ID=admir;Password=SezairI1.;" +
             "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        // login functiona which call sql statment with username and password it matches it with 
        // the existing one
        public async Task<Register> login(string username, string password)
        {
            if (username != null && password != null)
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM REGISTER WHERE Username = " + username + " AND " + " Password = " + password, conn);
                Task<SqlDataReader> red = sqlCommand.ExecuteReaderAsync();
                Register newRegister = new Register();

                SqlDataReader reader = await red;
                while (await reader.ReadAsync())
                {
                    newRegister = RegisterMapper.DbToRegister(reader);
                }
                return newRegister;
            }
            return null;

        }


        // get's all users with sql command from Register table and returns a list of registers
        public async Task<List<Register>> getAllUsers()
        {

            SqlCommand command = new SqlCommand($"SELECT * FROM Register", conn);
            command.Connection.Open();

            Task<SqlDataReader> red = command.ExecuteReaderAsync();

            List<Register> userlist = new List<Register>();

            SqlDataReader reader = await red;

            while (await reader.ReadAsync())
            {
                Register register = RegisterMapper.DbToRegister(reader);
                userlist.Add(register);
            }
            return userlist;
        }

        //Signup new employee
        public async Task<Register> signup(Register newRegister)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO Register (FirstName, LastName, Username, Password, Confirm) VALUES (@FirstName,@LastName,@Username,@Password,@Confirm);", conn);

            command.Connection.OpenAsync();

            command.Parameters.AddWithValue("@FirstName", newRegister.FName);
            command.Parameters.AddWithValue("@LastName", newRegister.LName);
            command.Parameters.AddWithValue("@Username", newRegister.Username);
            command.Parameters.AddWithValue("@Password", newRegister.Password);
            command.Parameters.AddWithValue("@Confirm", newRegister.Confirm);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 1)
            {
                conn.Close();
                return newRegister;
            }
            else
            {
                return null;
            }
        }

        // Adds a new ticket to Tickets table 
        public async Task<Tickets> addTicket(Tickets ticket)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO Tickets (EmpId, Reimb, Value, Descp, Status) VALUES (@EmpId, @Reimb, @Value, @Descp, @Status);", conn);

            await command.Connection.OpenAsync();

            command.Parameters.AddWithValue("@EmpId", ticket.empId);
            command.Parameters.AddWithValue("@Reimb", ticket.reimbursment);
            command.Parameters.AddWithValue("@Value", ticket.valueDollar);
            command.Parameters.AddWithValue("@Descp", ticket.description);
            command.Parameters.AddWithValue("@Status", ticket.status);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 1)
            {
                conn.Close();
                return ticket;
            }
            else
            {
                return null;
            }
        }

        Task<Tickets> approveTicket(string status)
        {
            throw new NotImplementedException();
        }

        //Returns a list of tickets with specific emp id and status pending
        public async Task<List<Tickets>> getAllPendingTickets(int empId, string status)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Tickets where empId = " + empId + " AND " + " status = " + status, conn);
            command.Connection.Open();

            Task<SqlDataReader> red = command.ExecuteReaderAsync();

            List<Tickets> ticketsList = new List<Tickets>();
            SqlDataReader reader = await red;

            while (await reader.ReadAsync())
            {
                Tickets tickets = TicketWrapper.DbToRegister(reader);
                ticketsList.Add(tickets);
            }
            return ticketsList;
        }

        //Returns a list of tickets with specific emp id
        public async Task<List<Tickets>> getByUserId(int empId)
        {
             SqlCommand command = new SqlCommand($"SELECT * FROM Tickets where empId = " + empId , conn);
            command.Connection.Open();

            Task<SqlDataReader> red = command.ExecuteReaderAsync();

            List<Tickets> ticketsList = new List<Tickets>();
            SqlDataReader reader = await red;

            while (await reader.ReadAsync())
            {
                Tickets tickets = TicketWrapper.DbToRegister(reader);
                ticketsList.Add(tickets);
            }
            return ticketsList;
        }

        Task<Tickets> IRepoLayerClass.approveTicket(string status)
        {
            throw new NotImplementedException();
        }
    }

}