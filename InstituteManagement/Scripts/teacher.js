$(document).ready(function () {
    getDepartment();
});
var BaseUrl = "http://45.35.4.250/institutemgmt/api/";

function onClick()
{
    var teacher = {
        First_Name: $('#fname').val(),
        Midde_Name: $('#mname').val(),
        Last_Name: $('#lname').val(),
        Address: $('#address').val(),
        DOB: $('#datetimepickerbirth').val(),
        JoinDate:$.datepicker.formatDate('yy/mm/dd', new Date()),
        City: $('#city').val(),
        Pin: $('#pin').val(),
        Country: $('#country').val(),
        EmergencyContactNo: $('#emergencyno').val(),
        ContactNo: $('#contactno').val(),
        EmailID: $('#email').val(),
        BloodGroup: $('#selectbloodgroup').val(),
        Designation: $('#designation').val(),
        Payment: $('#payment').val(),
        Photo: '',
        IsResume: 'false',
        DeptId: $('#department').val(),
        Gender: $("input[name='gender']:checked").val(),
        UserName: $('#email').val(),
        Password: $('#contactno').val(),
        JobType: '1',
        WorkType: '2'
    }
//    var teacher = {
//"First_Name": "Amitab",
//        "Midde_Name": "H",
//        "Last_Name": "Bacchan",
//        "Address": "Nariman Point",
//        "DOB": "1964-01-01T00:00:00",
//        "City": "Mumbai",
//        "Pin": "431001",
//        "Country": "India",
//        "EmergencyContactNo": "7773911718",
//        "ContactNo": "1234567890",
//        "EmailID": "amitb@gmail.com",
//        "BloodGroup": "AB+",
//        "Designation": "Maths Teacher",
//        "Payment": 12000,
//        "Photo": "",
//        "IsResume": true,
//        "DeptId": "1",
//        "Gender": "Male",
//        "UserName": "amitabh1",
//        "Password": "aajkhushtobohothoge1",
//        "JobType": "1",
//        "WorkType": "1"
//    }

    $.ajax({
        type: "POST",
        url: BaseUrl+"Teacher/CreateTeacher",
        contentType: "application/json; charset=UTF-8",
        dataType: "json",
        data: JSON.stringify(teacher),
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
        url: BaseUrl+"Department/getdepartment/0",
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
                //var options = "<tr><td>" + item.DepartmentID + "</td>"
                //+ "<td>" + item.Department_Name + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' onclick='setValueforEdit(" + '"' + item.DepartmentID + '","' + item.Department_Name +'"' + ")' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
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