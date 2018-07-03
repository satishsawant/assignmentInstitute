$(document).ready(function () {
    getDepartment();
    GetAllStudents();
});

function AddNewStudent() {

    var studentData = {
        First_Name: $('#first').val(),
        Middle_Name: $('#Middle').val(),
        Last_Name: $('#Last').val(),
        Address1: $('#address1').val(),
        Address2: $('#address2').val(),
        City: $('#city').val(),
        Pincode: $('#pincode').val(),
        Country: $('#country').val(),
        EmergencyContactNo: $('#EmrgNo').val(),
        ContactNo: $('#MobNo').val(),
        EmailID: $('#email').val(),
        BloodGroup: $('#bloodGrpOps').val(),
        Photo: $('#photo').val(),
        DeptId: $('#department').val(),
        Gender: $("input[name='gender_option']:checked").val(),
        DateOfBirth: $('#datetimepicker').val(),
        ParentsName: $('#PartNm').val(),
        ParentsMobileNo: $('#PartMobNo').val(),
        UserName: $('#UserName').val(),
        Password: $('#Password').val(),
    };

    $.ajax({
        type: "POST",
        url: "http://45.35.4.250/institutemgmt/api/student/createstudent",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(studentData),
        success: function (data) {
            alert(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

// GET ALL
function GetAllStudents() {
    debugger;
    $.ajax({
        type: "GET",
        url: "http://45.35.4.250/institutemgmt/api/student/GetStudents/0",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            var success = data.Success;
            var arr = [];
            arr = data.Student;
            window.stud = arr;
            $.each(arr, function (key, objData) {
                //stringify
                //var jsonData = JSON.stringify(value);
                ////Parse JSON
                //var objData = $.parseJSON(jsonData);
                var id = objData.StudentID;
                var fname = objData.First_Name;
                var Mname = objData.Middle_Name;
                var lname = objData.Last_Name;
                var add1 = objData.Address1;
                var add2 = objData.Address2;
                var gender = objData.Gender;
                var bloodgroup = objData.BloodGroup;
                var city = objData.City;
                var country = objData.Country;
                var contactno = objData.ContactNo;
                var emergencycontactno = objData.EmergencyContactNo;
                var dob = objData.DateOfBirth;
                var depid = objData.DeptId;
                var un = objData.UserName;
                var pass = objData.Password;
                var pin = objData.Pincode;
               
               // var email = objData.EmailID;
               



                $('<tr id="Tr_stud_' + id + '"><td>' + id + '</td><td>' + fname +
                                    '</td><td>' + Mname + '</td><td>' + lname + '</td><td>' + add1 + '</td><td>' + contactno + '</td><td>' +
                                    gender + '</td><td>' + bloodgroup + '</td><td>' + dob + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' onclick='EditStudent(" + key + ")'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>")
                                    .appendTo('#mytable');

            });
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error fun
    });
}

function EditStudent(key) {
    debugger;
    if (window.stud) {
        var stud = window.stud[key];
        $('#StudentEditModel').modal('show');
        $('#editfirst').val(stud.First_Name);
        $('#editMiddle').val(stud.Middle_Name);
        $('#editLast').val(stud.Last_Name);
        $('#editaddress1').val(stud.Address1);
        $('#editaddress2').val(stud.Address2);
        $('#editcity').val(stud.City);
        $('#editcountry').val(stud.Country);
        $('#editpincode').val(stud.Pincode);
        $('#editEmrgNo').val(stud.EmergencyContactNo);
        $('#editMobNo').val(stud.ContactNo);
       // $('#editEmail').val(stud.EmailID);
        $('#editbloodGrpOps').val(stud.BloodGroup);
        $('#editphoto').val(stud.Photo);
        $('#editdepartment').val(stud.DepartmentID);
        $('#editdatetimepicker').val(stud.DateOfBirth);
        $('#editPartNm').val(stud.ParentsName);
        $('#editPartMobNo').val(stud.ParentsMobileNo);
        //$('#editgender_option').val(stud.Gender);

       
         
    }
}
function setValueforEdit() {
    debugger;
    alert('alert1');
    if (window.selectedstud) {
        alert(window.selectedstud.First_Name);
    }
    var newobj = window.selectedstud;

    $('#editfirst').val(newobj.First_Name);
}

function getDepartment() {
    debugger;
    $.ajax({
        type: "GET",
        url: "http://45.35.4.250/institutemgmt/api/Department/getdepartment/0",
        contentType: "application/json;",
        dataType: 'json',
        success: function (data) {
            // alert(data);
            //var res = JSON.parse(data);
            var teachers = data.success;
            var arr = [];
            arr = data.departments;
            $.each(arr, function (i, item) {
                var options = "<option class='dropdown-item' value='" + item.DepartmentID + "'>" + item.Department_Name + "</option>";
                $('#department').append(options);
                $('#editdepartment').append(options);
            }); //End of foreach Loop   
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

//DELETE
function DeleteStudent() {
    $.ajax({
        type: "DELETE",
        url: "http://45.35.4.250/institutemgmt/api/student",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            alert("success.... " + data);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

function UpdateStudent() {
    debugger;
     
    var studentData = {
        StudentID : $('#studid').val(),
        First_Name: $('#editfirst').val(),
        Middle_Name: $('#editMiddle').val(),
        Last_Name: $('#editLast').val(),
        Address1: $('#editaddress1').val(),
        Address2: $('#editaddress2').val(),
        City: $('#editcity').val(),
        Pincode: $('#editpincode').val(),
        Country: $('#editcountry').val(),
        EmergencyContactNo: $('#editEmrgNo').val(),
        ContactNo: $('#editMobNo').val(),
        EmailID: $('#editEmail').val(),
        BloodGroup: $('#editbloodGrpOps').val(),
        Photo: $('#editphoto').val(),
        DeptId: $('#editdepartment').val(),
        Gender: $("input[name='editgender_option']:checked").val(),
        DateOfBirth: $('#editdatetimepicker').val(),
        ParentsName: $('#editPartNm').val(),
        ParentsMobileNo: $('#editPartMobNo').val(),
       
    };

    $.ajax({
        type: "POST",
        url:"http://45.35.4.250/institutemgmt/api/student/UpdateStudent",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(studentData),
        success: function (data) {
            if (data = 'success')
            { alert('Updated Successfully') }
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    $('#edit').modal('toggle');
}