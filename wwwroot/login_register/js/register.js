function genderChangeBackgroundColor(gender) {
    console.log("H")
    const maleLabel = document.getElementById('maleLabel');
    const femaleLabel = document.getElementById('femaleLabel');

    if (gender == 'male') {
        maleLabel.setAttribute("style", "background-color: #207dff !important;" +
            "color:#fff!important; ");

        femaleLabel.setAttribute("style", "background-color: #edf2f5 !important;" +
            "color:#000 !important;");
    } else {
        femaleLabel.setAttribute("style", "background-color: #cf1260 !important;" +
            "color:#fff!important; ");

        maleLabel.setAttribute("style", "background-color: #edf2f5 !important;" +
            "color:#000 !important; ");
    }
}

