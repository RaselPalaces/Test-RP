describe("CRUD EquipoMedico", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:8100"); //Frontend de Produccion
    });

    //Servicio API - GetUsuarios()
    it("GetEquipoMedico()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(4).click(); // click en el TAB de Usuarios
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    //Servicio API - AddUsuario(entidad)
    it("AddEquipoMedico(entidad)", () => {
        cy.get("ion-tab-button").eq(4).click(); // click en el TAB de Usuarios
        cy.wait(1000);//Esperar 1 seg.

        cy.get("#nombreEquipo")
            .type("insertar nombreEquipo cypress", { delay: 100 })
            .should("have.value", "insertar nombreEquipo cypress");

        cy.wait(500);//Esperar medio seg.

        cy.get("#descripcionProblema")
            .type("insertar descripcionProblema cypress", { delay: 100 })
            .should("have.value", "insertar descripcionProblema cypress");

        cy.wait(500);//Esperar medio seg.

        cy.get("#estadoReparacion")
            .type("insertar estadoReparacion cypress", { delay: 100 })
            .should("have.value", "insertar estadoReparacion cypress");

        cy.wait(500);//Esperar medio seg.

        cy.get("#addEquipoMedico").not("[disabled]").click();
    });
});