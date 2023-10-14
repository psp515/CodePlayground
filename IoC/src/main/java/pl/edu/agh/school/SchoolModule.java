package pl.edu.agh.school;

import com.google.inject.AbstractModule;
import com.google.inject.Provides;
import jdk.jfr.Name;
import pl.edu.agh.logger.Logger;
import pl.edu.agh.school.interfaces.ClassStorageFileName;
import pl.edu.agh.school.interfaces.TeachersStorageFileName;
import pl.edu.agh.school.persistence.ISerializablePersistenceManager;
import pl.edu.agh.school.persistence.SerializablePersistenceManager;

public class SchoolModule extends AbstractModule {

    @Provides
    public ISerializablePersistenceManager providePersistenceManager(SerializablePersistenceManager manager)
    {
        return manager;
    }

    @Provides
    public Logger provideLogger(Logger logger){
        return logger;
    }

    @Provides
    @TeachersStorageFileName
    public String provideTeachersStorageFileName()
    {
        return "teachers.dat";
    }
    @Provides
    @ClassStorageFileName
    public String provideClassStorageFileName()
    {
        return "classes.dat";
    }
}
