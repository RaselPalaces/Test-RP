describe("CRUD OrdenReparacion", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:8100"); //Frontend de Produccion
    });

    //Servicio API - GetUsuarios()
    it("GetOrdenReparacion()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(5).click(); // click en el TAB de Usuarios
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    //Servicio API - AddUsuario(entidad)
    it("AddOrdenReparacion(entidad)", () => {
        cy.get("ion-tab-button").eq(5).click(); // click en el TAB de Usuarios
        cy.wait(1000);//Esperar 1 seg.

        cy.get("#numeroOrden")
            .type("insertar numeroOrden cypress", { delay: 100 })
            .should("have.value", "insertar numeroOrden cypress");

        cy.wait(500);//Esperar medio seg.

        cy.get("#costoEstimado")
            .type("1", { delay: 100 })
            .should("have.value", "1");

        cy.wait(500);//Esperar medio seg.

        cy.get("#idEquipoMedico")
            .type("6", { delay: 100 })
            .should("have.value", "6");

        cy.wait(500);//Esperar medio seg.

        cy.get("#idUsuario")
            .type("1", { delay: 100 })
            .should("have.value", "1");

        cy.wait(500);//Esperar medio seg.

        cy.get("#addOrdenReparacion").not("[disabled]").click();
    });
});