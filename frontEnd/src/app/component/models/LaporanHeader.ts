import { Guid } from "guid-typescript";
import { User } from "src/app/models/UserModel";
import { LaporanItem } from "./LaporanItem";

export class LaporanHeader {
    laporanHeaderId: Guid = Guid.createEmpty();
    judulLaporan: string = "";
    keterangan: string = "";
    statusLaporan: string = "";
    userId: string = "";
    tglBuat: Date = null;
    tglSelesai: Date = null;
    user: User = new User;
    laporanItems: LaporanItem[] = [];
    status: string = "";
}