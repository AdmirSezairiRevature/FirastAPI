using RepoLayer;
using ModelsLayer;
namespace BusinessLayer
{
    public interface IBusinessClass
    {
        Task<Register> signUp(Register newRegister);
        Task<Register> login(string username, string password);

        Task<List<Register>> getAllUsers();

        Task<List<Tickets>> getAllPendingTickets(int empId, string status);

        Task<List<Tickets>> getByUserId(int empId);

        Task<Tickets> addTicket(Tickets ticket);
    }
    public class BusinessClass : IBusinessClass
    {
        private readonly IRepoLayerClass _repo;

        public BusinessClass(IRepoLayerClass repo)
        {
            _repo = repo;
        }
        public async Task<Register> login(string username, string password)
        {
            Register register = await this._repo.login(username, password);
            return register;
        }

        public async Task<Register> signUp(Register newRegister)
        {
            Register newSignup = await this._repo.signup(newRegister);
            Console.WriteLine("Added new user " + newSignup.Username);
            return newSignup;
        }

        public async Task<List<Register>> getAllUsers()
        {
            List<Register> userList = await this._repo.getAllUsers();
            return userList;
        }

        public async Task<List<Tickets>> getAllPendingTickets(int empId, string status)
        {
            List<Tickets> allPendingTickets = await this._repo.getAllPendingTickets(empId, status);
            return allPendingTickets;
        }

        public async Task<List<Tickets>> getByUserId(int empId)
        {
            List<Tickets> allTicketsByUserId = await this._repo.getByUserId(empId);
            return allTicketsByUserId;
        }
        public async Task<Tickets> addTicket(Tickets ticket)
        {
            Tickets newTicket = await this._repo.addTicket(ticket);
            return newTicket;
        }

    }

}