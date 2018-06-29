$(document).ready(function () {
    getDepartment();
});

function onClick()
{
    debugger;
    var teacher = new Object();
    teacher.First_Name = $('#fname').val();
    teacher.Midde_Name = $('#mname').val();
    teacher.Last_Name = $('#lname').val();
    teacher.Address = $('#address').val();
    teacher.DOB = $('#datetimepickerbirth').val();
    teacher.City = $('#city').val();
    teacher.Pin = $('#pin').val();
    teacher.Country = $('#country').val();
    teacher.EmergencyContactNo = $('#emergencyno').val();
    teacher.ContactNo = $('#contactno').val();
    teacher.EmailID = $('#email').val();
    teacher.BloodGroup = $('#selectbloodgroup').val();
    teacher.Designation = $('#designation').val();
    teacher.Payment = $('#payment').val();;
    teacher.Photo = '';
    teacher.IsResume = '0';
    teacher.DeptId = $('#department').val();
    teacher.Gender = $("input[name='gender']:checked").val();
    teacher.UserName = $('#email').val();
    teacher.Password = $('#contactno').val();
    teacher.JobType = '1';
    teacher.WorkType = '2';

    $.ajax({
        type: "POST",
        url: "http://localhost:50076/api/Teacher/CreateTeacher",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: teacher,
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

function getDepartment()
{
    debugger;
    $.ajax({
        type: "GET",
        url: "http://localhost:50076/api/Department/getdepartment/0",
        contentType: "application/json;",
        dataType: 'json',
        success: function (data) {
            // alert(data);
            //var res = JSON.parse(data);
            var teachers = data.success;
            var arr = [];
            arr=data.departments;
            $.each(arr, function (i, item) {
                    var options = "<option class='dropdown-item' value='" + item.DepartmentID + "'>" + item.Department_Name + "</option>";
                    $('#department').append(options);
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