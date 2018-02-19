export class Cliente {
    constructor(public Id: number = 0, public Nome: string = null,
        public Cpf: string = null, public DataNascimento: Date = new Date,
        public Peso: number = null, public Estado: string = '') { }
}