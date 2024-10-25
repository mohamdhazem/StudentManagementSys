using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public interface ITraineeRepository:IRepository<Trainee>
    {
        public CrsResult? crsResult(int id, int crsid);
        public List<CrsResult>? crsResults(int id);
        public List<Trainee> FilteredTrainees(string name);

    }
}
