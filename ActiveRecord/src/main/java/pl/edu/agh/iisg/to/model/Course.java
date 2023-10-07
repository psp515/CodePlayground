package pl.edu.agh.iisg.to.model;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.LinkedList;
import java.util.List;
import java.util.Optional;
import java.util.logging.Logger;

import pl.edu.agh.iisg.to.executor.QueryExecutor;

public class Course {

    public static final String TABLE_NAME = "course";

    private static final Logger logger = Logger.getGlobal();

    private final int id;

    private final String name;

    private List<Student> enrolledStudents;

    private boolean isStudentsListDownloaded = false;

    Course(final int id, final String name) {
        this.id = id;
        this.name = name;
    }

    public static Optional<Course> create(final String name) {
        String insertSql = "INSERT INTO course (name) VALUES (?);";
        Object[] args = {
                name
        };

        try {
            int id = QueryExecutor.createAndObtainId(insertSql, args);
            return Course.findById(id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return Optional.empty();
    }

    public static Optional<Course> findById(final int id) {
        String findByIdSql = "SELECT * FROM course WHERE id = ?";
        Object[] args = {
                id
        };

        try (ResultSet rs = QueryExecutor.read(findByIdSql, args)) {
            if (rs.next()) {
                return Optional.of(new Course(
                        rs.getInt("id"),
                        rs.getString("name")
                ));
            } else {
                return Optional.empty();
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return Optional.empty();
    }

    public boolean enrollStudent(final Student student) {
        String enrollStudentSql = "INSERT INTO student_course (student_id, course_id) VALUES(?,?)";
        Object[] args = { student.id(), this.id() };

        try {
            var result = QueryExecutor.createAndObtainId(enrollStudentSql, args);
            return result > 0;
        } catch (SQLException e) {

        }

        return false;
    }

    public List<Student> studentList()
    {
        String sql = "SELECT s.id, s.first_name, s.last_name, s.index_number FROM student AS s INNER JOIN student_course AS sc ON s.id = sc.student_id WHERE sc.course_id = ?";

        try{
            var rs = QueryExecutor.read(sql, id());

            List<Student> resultList = new LinkedList<>();
            while(rs.next()){
                resultList.add(new Student(
                        rs.getInt("id"),
                        rs.getString("first_name"),
                        rs.getString("last_name"),
                        rs.getInt("index_number")));
            }

            return resultList;
        }
        catch (SQLException e){
            e.printStackTrace();
        }
        catch (Exception e){
            e.printStackTrace();
        }

        return new LinkedList<>();

        // Below code that does n+1 request to get all objects -> BAD
        /*String findStudentListSql = "SELECT * from student_course WHERE id = ?";
        Object[] args = {
                this.id()
        };
        ResultSet rs = null;
        try {
             rs = QueryExecutor.read(findStudentListSql, args);
        } catch (SQLException e) {
            return new LinkedList<>();
        }

        List<Student> resultList = new LinkedList<>();
        while(true)
        {
            try {
                if (!rs.next())
                    break;

                var studentId = rs.getInt("student_id");
                var student = Student.findById(studentId);

                if(student.isEmpty())
                    continue;

                resultList.add(student.get());

            } catch (SQLException e) {
                throw new RuntimeException(e);
            }

        }

        return resultList;*/
    }

    public List<Student> cachedStudentsList() {

        if(enrolledStudents == null) {
            enrolledStudents = studentList();
        }

        return enrolledStudents;
    }

    public int id() {
        return id;
    }

    public String name() {
        return name;
    }

    public static class Columns {

        public static final String ID = "id";

        public static final String NAME = "name";

    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Course course = (Course) o;

        if (id != course.id) return false;
        return name.equals(course.name);
    }

    @Override
    public int hashCode() {
        int result = id;
        result = 31 * result + name.hashCode();
        return result;
    }
}
