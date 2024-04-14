function showAlert(name) {
    alert('Hello ' + name)
}

function callStaticCSharpMethod() {
    DotNet.invokeMethodAsync('BooksStore', 'AddTwoNumbers', 3, 5)
        .then(data => {
            console.log('3 + 5 = ' + data)
        })
}

function triggerOnWindowResized(dotnetObjRef) {
    window.onresize = function () {
        dotnetObjRef.invokeMethodAsync('OnWindowResized', window.innerWidth, window.innerHeight);
    }
}