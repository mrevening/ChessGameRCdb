export { ActionType, ActionTypeEnum }

class ActionType {
    public id: number
    public name: string

    constructor(a: ActionTypeEnum) {
        this.id = a.valueOf()
        this.name = a.toString()
    }
}

enum ActionTypeEnum { Move = 1, Capture, EnPassant, Promotion, Castle, Check, Mate, PromotionWithCapture }