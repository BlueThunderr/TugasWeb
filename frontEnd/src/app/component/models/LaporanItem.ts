import { Guid } from "guid-typescript";
import { User } from "./user";

export class LaporanItem {
    laporanItemId: Guid = Guid.createEmpty();
    laporanHeaderId: Guid = Guid.createEmpty();
    keterangan: string = "";
    tglBuat: Date = null;
    userId: Guid = Guid.createEmpty();
    isDeteled: boolean = false;
    user: User = new User;
}