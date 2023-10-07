package pl.edu.agh.iisg.to.dao;

import pl.edu.agh.iisg.to.model.Course;
import pl.edu.agh.iisg.to.model.Grade;
import pl.edu.agh.iisg.to.model.Student;

import javax.persistence.PersistenceException;

public class GradeDao extends GenericDao<Grade> {

    public boolean gradeStudent(final Student student, final Course course, final float grade) {

        try {

            Grade currentGrade = new Grade(grade, student, course);
            course.gradeSet().add(currentGrade);
            student.gradeSet().add(currentGrade);

            update(currentGrade);
            return true;
        }
        catch (PersistenceException e){
            e.printStackTrace();
        }

        return true;
    }


}
