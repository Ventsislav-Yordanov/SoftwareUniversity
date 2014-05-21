<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<project default="create_run_jar" name="Create Runnable Jar for Project Intro-Java-Homework">
    <!--this file was created by Eclipse Runnable JAR Export Wizard-->
    <!--ANT 1.7 is required                                        -->
    <target name="create_run_jar">
        <jar destfile="D:/JAVA/Intro-Java-Homework/myJar.jar" filesetmanifest="mergewithoutmain">
            <manifest>
                <attribute name="Main-Class" value="GeneratePDFByExternalLibrary"/>
                <attribute name="Class-Path" value="."/>
            </manifest>
            <fileset dir="D:/JAVA/Intro-Java-Homework/bin"/>
            <zipfileset excludes="META-INF/*.SF" src="D:/JAVA/Intro-Java-Homework/itextpdf-5.5.0.jar"/>
        </jar>
    </target>
</project>
