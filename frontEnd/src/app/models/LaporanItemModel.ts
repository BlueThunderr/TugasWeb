import { User } from "./UserModel";

export class LaporanItem {
    keterangan: string = "";
    tglBuat: Date = new Date();
    isDeteled: boolean = false;
    user: User = new User;
}