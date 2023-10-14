package pl.edu.agh.school;

import com.google.inject.Guice;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.junit.jupiter.MockitoExtension;
import pl.edu.agh.school.persistence.SerializablePersistenceManager;

import static org.junit.jupiter.api.Assertions.assertEquals;

@ExtendWith(MockitoExtension.class)
public class SchoolModuleTest {

    @Test
    public void testSetSchoolClass()
    {
        var injector = Guice.createInjector(new SchoolModule());

        var spm1 = injector.getInstance(SerializablePersistenceManager.class);
        var spm2 = injector.getInstance(SerializablePersistenceManager.class);


        assertEquals(spm1.getLogger(), spm2.getLogger());
    }
}
