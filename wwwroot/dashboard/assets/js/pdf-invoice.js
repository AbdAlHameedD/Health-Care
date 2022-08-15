window.onload = function () {
    document.getElementById('download')
        .addEventListener('click', () => {
            const invoice = document.getElementById('invoice');
            html2pdf(invoice, {
                filename: 'invoice.pdf'
            }).from(invoice).save();
        })
}