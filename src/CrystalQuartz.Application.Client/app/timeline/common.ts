﻿export interface IActivitySize {
    left: number;
    width: number;
}

export interface IRange {
    start: number;
    end: number;
}

export interface ITimelineTickItem {
    tickDate: number;
    width: number;
}

export interface ITimelineActivityOptions {
    key: string;
    startedAt?: number;
    completedAt?: number;
}

export interface ITimelineGlobalActivityOptions {
    occurredAt: number;
    itemKey: string;
    scope: number;
    typeCode: string;
    //description: string;
}

export interface ITimelineSlotOptions {
    key: string;
}