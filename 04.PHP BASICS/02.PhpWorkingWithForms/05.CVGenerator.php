<!doctype html>

<?php
if (isset($_POST['firstName']) && isset($_POST['secondName']) &&
    isset($_POST['Email']) && isset($_POST['phone']) && isset($_POST['sex'])&&
    isset($_POST['nationality']) && isset($_POST['companyName']) &&isset($_POST['from']) &&
    isset($_POST['to']) && isset($_POST['progLanguages']) && isset($_POST['comprehension']) &&
    isset($_POST['reading']) && isset($_POST['writing'])) {

    $firstName = $_POST['firstName'];
    $lastName = $_POST['secondName'];
    $email = $_POST['Email'];
    $phone = $_POST['phone'];
    $sex = $_POST['sex'];
    $birthDate = $_POST['birthDate'];
    $nationality = $_POST['nationality'];
    $companyName = $_POST['companyName'];
    $workedFrom = $_POST['from'];
    $workedTo = $_POST['to'];
    $programmingLanguage = $_POST['progLanguages'];
    $levelProgramming = $_POST['level'];
    $speakingLanguages = $_POST['language-text'];
    $comprehension = $_POST['comprehension'];
    $reading = $_POST['reading'];
    $writing = $_POST['writing'];
    $bCategory = '';
    $cCategory = '';
    $aCategory = '';
    if(isset($_POST['bCategory'])) {
        $bCategory = 'B';
    }
    if(isset($_POST['aCategory'])) {
        $aCategory = 'A';
    }
    if(isset($_POST['cCategory'])) {
        $cCategory = 'C';
    }

    if(!preg_match('/[^A-Za-z]/', $firstName) && !preg_match('/[^A-Za-z]/', $lastName)
        && !preg_match('/[^A-Za-z0-9 ]/', $companyName) && strlen($firstName) <= 20 && strlen($firstName) >= 2 &&
        strlen($lastName) <= 20 && strlen($lastName) >= 2 &&
        strlen($companyName) <= 20 && strlen($companyName) >= 2 &&
        !preg_match("/^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/", $birthDate) &&
        !preg_match('/[^0-9\+\-\s]/', $phone)
    ) {
        $personalInfoTable = '<table><thead><tr><th colspan="2">Personal Information</th></tr></thead><tbody>' .
            '<tr><td>First Name</td><td>' . $firstName . '</td></tr><td>Last Name</td><td>' . $lastName  . '</td></tr>' .
            '<tr><td>Email</td><td>' . $email . '</td></tr>' .
            '<tr><td>Phone</td><td>' . $phone . '</td></tr>' .
            '<tr><td>Gender</td><td>' . $sex . '</td></tr>' .
            '<tr><td>Birth Date</td><td>' . $birthDate . '</td></tr>' .
            '<tr><td>Nationality</td><td>' . $nationality . '</td></tr></tbody></table>';
        $lastWorkTable = '<table><thead><tr><th colspan="2">Last Work Position</th></tr></thead><tbody>' .
            '<tr><td>Company Name</td><td>' . $companyName . '</td></tr>' .
            '<tr><td>From</td><td>' . $workedFrom . '</td></tr>' .
            '<tr><td>To</td><td>' . $workedTo . '</td></tr></tbody></table>';
        $computerSkillsTable = '<table><thead><tr><th colspan="2">Computer Skills</th></tr></thead><tbody>' .
            '<tr><td>Programming Languages</td><td><table><thead><tr><th>Language</th><th>Skill Level</th></tr></thead>' .
            '<tbody>';
        for($i = 0; $i < count($levelProgramming) ;$i++) {
            $computerSkillsTable .= '<tr>';
            $computerSkillsTable .= '<td>' . $programmingLanguage[$i] . '</td>';
            $computerSkillsTable .= '<td>' . $levelProgramming[$i] . '</td>';
            $computerSkillsTable .= '</tr>';

        }
        $computerSkillsTable .= '</tbody></table></tr></tbody></table>';

        $otherSkills = '<table><thead><tr><th colspan="2">Other Skills</th></tr></thead><tbody>' .
            '<tr><td>Languages</td><td><table><thead><th>Language</th><th>Comprehension</th>' .
            '<th>Reading</th><th>Writing</th></tr>';

        for($i = 0; $i < count($comprehension) ;$i++) {
            $otherSkills .= '<tr>';
            $otherSkills .= '<td>' . $speakingLanguages[$i] . '</td>';
            $otherSkills .= '<td>' . $comprehension[$i] . '</td>';
            $otherSkills .= '<td>' . $reading[$i] . '</td>';
            $otherSkills .= '<td>' . $writing[$i] . '</td>';
        }
        $otherSkills .= '</tbody></table></tr><tr><td>Driver`s License</td><td>' . $bCategory . " ".  $aCategory. "" . $cCategory .'</td></tr>';
        $otherSkills .= '</tbody></table>';
    }
}
?>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <style>
        table ,th , td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        table {
            margin: 10px;
        }
    </style>
</head>
<body>

<script>
    // add programming language
    var idCounter = 0;
    function addProgLang() {
        var myDiv = document.createElement("div");
        myDiv.setAttribute("id", "inputBox" + idCounter);
        idCounter++;
        myDiv.innerHTML = "<input type='text' name='progLanguages[]' id='prog-langs' required='required'>" +
            "<select name='level[]' id='level' required='required'>" +
            "<option value='Beginner'>Beginner</option>" +
            "<option value='Programmer'>Programmer</option>" +
            "<option value='Ninja'>Ninja</option>" +
            "</select>" +
            "<br/>";
        document.getElementById("parent-prog-lang").appendChild(myDiv);
    }

    // remove programming language
    function removeProgLang() {
        var getChild = document.getElementById("parent-prog-lang").lastChild;
        if (getChild.id != "ipnutBox0") {
            document.getElementById("parent-prog-lang").removeChild(getChild);
        }
    }

    // add speaking language
    var idLangCounter = 0;
    function addSpeakingLang() {
        var langParent = document.getElementById("speaking-lang-parent");
        var newDiv = document.createElement("div");
        newDiv.setAttribute("id", "lang" + idLangCounter);
        idLangCounter++;
        newDiv.innerHTML = "<input type='text' id='lang' name='language-text[]' required='required'/>" +
            "<select name='comprehension[]' id='comprehension' required='required'>" +
            "<option value='default' disabled selected>-Comprehension-</option>" +
            "<option value='beginner'>beginner</option>" +
            "<option value='intermediate'>intermediate</option>" +
            "<option value='advanced'>advanced</option>" +
            "</select>" +
            "<select name='reading[]' id='reading' required='required'>" +
            "<option value='default' disabled selected>-Reading-</option>" +
            "<option value='beginner'>beginner</option>" +
            "<option value='intermediate'>intermediate</option>" +
            "<option value='advanced'>advanced</option>" +
            "</select>" +
            "<select name='writing[]' id='writing'>" +
            "<option value='default' disabled selected>-Writing-</option>" +
            "<option value='beginner'>beginner</option>" +
            "<option value='intermediate'>intermediate</option>" +
            "<option value='advanced'>advanced</option>" +
            "</select>" +
            "<br/>";
        langParent.appendChild(newDiv);
    }

    // remove speaking language
    function removeSpeakingLang() {
        var lastElement = document.getElementById("speaking-lang-parent").lastChild;
        if  (lastElement.id != "lang0") {
            document.getElementById("speaking-lang-parent").removeChild(lastElement);
        }
    }

</script>


<form action="" method="post">
    <fieldset>
        <legend>Personal Information</legend>
        <input type="text" placeholder="First Name" name="firstName"/><br/>
        <input type="text" placeholder="Last Name" name="secondName"/><br/>
        <input type="text" placeholder="Email" name="Email"/><br/>
        <input type="text" placeholder="Phone Number" name="phone"/><br/>
        <label for="Female">Female</label>
        <input type="radio" name="sex" value="Female" id="Female"/>
        <label for="Male">Male</label>
        <input type="radio" name="sex" value="Male" id="Male"/> <br/>
        <label for="birthDate">Birth Date</label> <br/>
        <input type="text" id="birthDate" name="birthDate" placeholder="dd/mm/yyyy"/> <br/>
        <label for="nationality">Nationality</label> <br/>
        <select name="nationality" id="nationality">
            <option value="Bulgarian">Bulgarian</option>
            <option value="Albanian">Albanian</option>
            <option value="American">American</option>
        </select>
    </fieldset>
    <fieldset>
        <legend>Last Work Position</legend>
        <label for="companyName">Company Name</label>
        <input type="text" id="companyName" name="companyName"/><br/>
        <label for="from">From</label>
        <input type="text" id="from" placeholder="dd/mm/yyyy" name="from"/><br/>
        <label for="to">To</label>
        <input type="text" id="to" placeholder="dd/mm/yyyy" name="to"/><br/>
    </fieldset>
    <fieldset>
        <legend>Computer Skills</legend>
        <label for="prog-langs">Programming Languages</label><br/>
        <div id="parent-prog-lang">

        </div>
        <script>addProgLang();</script>
        <input type="button" name="remove-item" id="remove" value="Remove Language" onclick="removeProgLang()"/>
        <input type="button" name="progLang[]" id="add" value="Add Language" onclick="addProgLang()"/>
    </fieldset>
    <fieldset>
        <legend>Other Skills</legend>
        <label for="lang">Languages</label><br/>
        <div id="speaking-lang-parent">

        </div>
        <script> addSpeakingLang();</script>
        <input type="button" id="remove-lang" name="remove-lang" value="Remove Language" onclick="removeSpeakingLang()"/>
        <input type="button" id="remove-lang" name="remove-lang" value="Add Language" onclick="addSpeakingLang()"/><br/>
        <label for="driver">Driver`s License</label><br/>
        <label for="b-category">B</label>
        <input type="checkbox" name="bCategory" id="b-category"/>
        <label for="a-category">A</label>
        <input type="checkbox" name="aCategory" id="a-category"/>
        <label for="c-category">C</label>
        <input type="checkbox" name="cCategory" id="c-category"/>
    </fieldset>
    <input type="submit" name="submit-cv" id="submitBtn" onclick="submitAll()"/>
</form>
<div id="result">
    <?php
    if(isset($personalInfoTable) && isset($lastWorkTable) && isset($computerSkillsTable) && $otherSkills) {
        echo $personalInfoTable;
        echo $lastWorkTable;
        echo $computerSkillsTable;
        echo $otherSkills;
    }
    else {
        echo "Please enter a valid information to generate your CV";
    }
    ?>
</div>
</body>
</html>