function XX(num: String) {

    var httpRequest = new XMLHttpRequest;
    //   httpRequest.open("GET", "api/persons/GetPeopleByName/" + e.target.innerHTML + "/aa/bb");

        httpRequest.open("GET", "api/persons/GetAllPeople");
    //httpRequest.open("GET", "api/persons/GetPeopleByName/?para1=apollo&para2=Male");
        httpRequest.send();
        var x = 0;
        var xx = 100;
}

