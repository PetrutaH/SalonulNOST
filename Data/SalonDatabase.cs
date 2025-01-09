using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SalonulNOST.Models;

namespace SalonulNOST.Data
{
    public class SalonDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SalonDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            CreateTablesAsync();
        }

        private async Task CreateTablesAsync()
        {
            await _database.CreateTableAsync<Client>();
            await _database.CreateTableAsync<Service>();
            await _database.CreateTableAsync<Appointment>();
            await _database.CreateTableAsync<Employee>(); // Dacă ai un tabel de Employee
        }

        // CRUD pentru Client
        public Task<List<Client>> GetUsersAsync() => _database.Table<Client>().ToListAsync();

        public Task<Client> GetUserAsync(int id) =>
            _database.Table<Client>().FirstOrDefaultAsync(c => c.ClientID == id);

        public Task<int> SaveUserAsync(Client user) =>
            user.ClientID != 0 ? _database.UpdateAsync(user) : _database.InsertAsync(user);

        public Task<int> DeleteUserAsync(Client user) => _database.DeleteAsync(user);

        // CRUD pentru Service
        public Task<List<Service>> GetServicesAsync() => _database.Table<Service>().ToListAsync();

        public Task<Service> GetServiceAsync(int id) =>
            _database.Table<Service>().FirstOrDefaultAsync(s => s.ServiceID == id);

        public Task<int> SaveServiceAsync(Service service) =>
            service.ServiceID != 0 ? _database.UpdateAsync(service) : _database.InsertAsync(service);

        public Task<int> DeleteServiceAsync(Service service) => _database.DeleteAsync(service);

        // CRUD pentru Employee
        public Task<List<Employee>> GetEmployeesAsync() => _database.Table<Employee>().ToListAsync();

        public Task<Employee> GetEmployeeAsync(int id) =>
            _database.Table<Employee>().FirstOrDefaultAsync(e => e.EmployeeID == id);

        public Task<int> SaveEmployeeAsync(Employee employee) =>
            employee.EmployeeID != 0 ? _database.UpdateAsync(employee) : _database.InsertAsync(employee);

        public Task<int> DeleteEmployeeAsync(Employee employee) => _database.DeleteAsync(employee);

        // CRUD pentru Appointment
        public Task<List<Appointment>> GetAppointmentsAsync() => _database.Table<Appointment>().ToListAsync();

        public Task<Appointment> GetAppointmentAsync(int id) =>
            _database.Table<Appointment>().FirstOrDefaultAsync(a => a.AppointmentID == id);

        public Task<int> SaveAppointmentAsync(Appointment appointment) =>
            appointment.AppointmentID != 0 ? _database.UpdateAsync(appointment) : _database.InsertAsync(appointment);

        public Task<int> DeleteAppointmentAsync(Appointment appointment) => _database.DeleteAsync(appointment);
    }
}
