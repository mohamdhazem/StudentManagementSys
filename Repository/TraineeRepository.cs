using Microsoft.EntityFrameworkCore;
using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public class TraineeRepository:ITraineeRepository
    {
        private readonly Context context;
        public TraineeRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Trainee trainee)
        {
            context.Add(trainee);
        }
        public void Update(Trainee trainee)
        {
            context.Update(trainee);
        }
        public void Delete(Trainee trainee)
        {
            context.Remove(trainee);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public List<Trainee> GetAll()
        {
            return context.trainees.ToList();
        }
        public Trainee? GetById(int id)
        {
            return context.trainees.FirstOrDefault(d => d.id == id);
        }
        public CrsResult? crsResult(int id, int crsid)
        {
            CrsResult? crsResult = context.crsResults.Include(t => t.trainee)
                                                     .Include(c=>c.course)
                                                     .FirstOrDefault(c => c.courseId == crsid && c.traineeId == id);
            return crsResult;
        }
        public List<CrsResult>? crsResults(int id)
        {
            List<CrsResult>? crsResults = context.crsResults.Include(t => t.trainee)
                                                            .Include(c => c.course)
                                                            .Where(c =>c.traineeId == id).ToList();
            return crsResults;
        }

        public List<Trainee> FilteredTrainees(string name)
        {
            return context.trainees.Where(t=>t.name.Contains(name)).ToList();
        }

    }
}
