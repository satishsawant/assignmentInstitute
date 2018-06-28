$(document).ready(function () {
   
});

function onClick()
{
    debugger;
    var teacher = new Object();
    teacher.First_Name = $('#name').val();
    teacher.Midde_Name = $('#mname').val();
    teacher.Last_Name = $('#lname').val();
    teacher.Address = $('#address').val();
    teacher.DOB = $('#datetimepicker').val();
    teacher.City = $('#city').val();
    teacher.Pin = $('#pin').val();
    teacher.Country = $('#country').val();
    teacher.EmergencyContactNo = $('#emergencyno').val();
    teacher.ContactNo = $('#contactno').val();
    teacher.EmailID = $('#email').val();
    teacher.BloodGroup = $('#selectbloodgroup').val();
    teacher.Designation = $('#designation').val();
    teacher.Payment = '12000';
    teacher.Photo = '';
    teacher.IsResume = '0';
    teacher.DeptId = '1';
    teacher.Gender = 'Male';
    teacher.UserName = 'test';
    teacher.Password = 'test2';
    teacher.JobType = '1';
    teacher.WorkType = '2';

    $.ajax({
        type: "POST",
        url: "/api/Teacher/CreateTeacher",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: teacher,
        success: function (data) {

        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

////alert(JSON.stringify(data));                  
//$("#DIV").html('');
//var DIV = '';
//$.each(data, function (i, item) {
//    var rows = "<tr>" +
//        "<td id='RegdNo'>" + item.regNo + "</td>" +
//        "<td id='Name'>" + item.name + "</td>" +
//        "<td id='Address'>" + item.address + "</td>" +
//        "<td id='PhoneNo'>" + item.phoneNo + "</td>" +
//        "<td id='AdmissionDate'>" + Date(item.admissionDate,
//         "dd-MM-yyyy") + "</td>" +
//        "</tr>";
//    $('#Table').append(rows);
//}); //End of foreach Loop   
//console.log(data);