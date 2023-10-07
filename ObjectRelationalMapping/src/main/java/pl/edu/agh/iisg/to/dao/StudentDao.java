package pl.edu.agh.iisg.to.dao;

import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.Optional;

import org.hibernate.Session;
import pl.edu.agh.iisg.to.model.Course;
import pl.edu.agh.iisg.to.model.Student;
import pl.edu.agh.iisg.to.session.SessionService;

import javax.persistence.PersistenceException;

public class StudentDao extends GenericDao<Student> {

    public Optional<Student> create(final String firstName, final String lastName, final int indexNumber) {

        var student = new Student(firstName,lastName, indexNumber);

        try {
            var createdStudent = save(student);
            return Optional.ofNullable(createdStudent);
        }
        catch (PersistenceException e)
        {
            e.printStackTrace();
        }

        return Optional.empty();
    }

    public Optional<Student> findByIndexNumber(final int indexNumber) {

        try {
            String sql = "SELECT s.id, s.firstName, s.lastName, s.indexNumber FROM Student AS s where indexNumber = s.indexNumber";

            Session session = SessionService.getSession();

            var createdStudent = session.createQuery("SELECT s FROM Student s WHERE s.indexNumber = :indexNumber", Student.class)
                    .setParameter("indexNumber", indexNumber).getSingleResult();


            return Optional.ofNullable(createdStudent);
        }
        catch (PersistenceException e)
        {
            e.printStackTrace();
        }

        return Optional.empty();
    }

    public Map<Course, Float> createReport(final Student student) {

        var grades = student.gradeSet();
        Map<Course, Float> totalMap = new HashMap<>();
        Map<Course, Integer> totalCounter = new HashMap<>();

        for(var grade : grades)
        {
            totalMap.merge(grade.course(), grade.grade(), Float::sum);
            totalCounter.merge(grade.course(), 1, Integer::sum);
        }

        return totalMap.entrySet().stream()
                .collect(
                        HashMap::new,
                        (map, entry) -> map.put(entry.getKey(), entry.getValue() / totalCounter.get(entry.getKey())),
                        HashMap::putAll
                );
    }

}
