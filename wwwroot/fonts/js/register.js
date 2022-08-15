function genderChangeBackgroundColor(gender)
{
    const maleLabel = document.getElementById('maleLabel');
    const femaleLabel = document.getElementById('femaleLabel');
    
    if (gender == 'male'){
        maleLabel.style.backgroundColor = "#207dff";
        maleLabel.style.color = "#ffffff";

        femaleLabel.style.backgroundColor = "#edf2f5";
        femaleLabel.style.color = "#000000";
    } else {
        femaleLabel.style.backgroundColor = "#cf1260";
        femaleLabel.style.color = "#ffffff";

        maleLabel.style.backgroundColor = "#edf2f5";
        maleLabel.style.color = "#000000";
    }
}