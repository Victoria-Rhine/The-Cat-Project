function pageDetails() {
    document.getElementById("details").innerHTML =
        "<br />" + "Let's make sure things look right" + "<br /><br />" +
        "CHANGE DETAILS to edit" + "<br />" + "CONTINUE to add traits" + "<br />" + "ALL DONE to quit process"
}

function pageDetailsEnd() {
    document.getElementById("details").innerHTML =
        "<br />" + "Let's make sure things look right" + "<br /><br />" +
        "CHANGE DETAILS to edit" + "<br />" + "FINISH to see cat stats"
}

function getStats() {

    selectElement =
        document.querySelector('#select1');

    selection = selectElement.value;

    if (selection == "ages" || selection == "names") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showAges,
            error: errorOnAjax
        });
    }

    else if (selection == "colors") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showColors,
            error: errorOnAjax
        });
    }

    else if (selection == "breeds") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showBreeds,
            error: errorOnAjax
        });
    }

    else {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showPersonalities,
            error: errorOnAjax
        });
    }

};

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

function showAges(data) {
    for (var i = 0; i < data.length; i++) {
        $('#output').append($('<ul>' + data[i] + '</ul>'));
    }
}

function showBreeds(data) {
    for (var i = 0; i < data.length; i++) {
        $('#output').append($('<ul>' + data[i].Breeds + '</ul>'));
    }   
}

function showColors(data) {
    for (var i = 0; i < data.length; i++) {
        $('#output').append($('<ul>' + data[i].Colors + '</ul>'));
    }
}

function showPersonalities(data) {
    for (var i = 0; i < data.length; i++) {
        $('#output').append($('<ul>' + data[i].Personalities + '</ul>'));
    }
}


