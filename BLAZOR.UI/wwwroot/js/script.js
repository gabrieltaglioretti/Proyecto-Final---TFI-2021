window.getPreferenceId = function (preferenceId) {    

    const mp = new MercadoPago('TEST-8c07d331-5cb4-4403-aad0-ea7788945a53',
    {
        locale: 'es-AR'
    });


    const checkout = mp.checkout({
        preference: {
            id: preferenceId
        },
        render: {
            container: '.taglio',
            label: 'Pagar',
        }
    });
    console.log(preferenceId);
}